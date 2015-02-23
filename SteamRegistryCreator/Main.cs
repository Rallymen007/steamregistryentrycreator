using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SteamRegistryCreator
{
    public partial class Main : Form
    {
        private String Gpath;
        private List<Game> games;

        private delegate void AddGameHandler(Int32 id, String name, String path);
        private event AddGameHandler AddGame;

        public Main()
        {
            // Admin rights or not?
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                // not an admin
                MessageBox.Show("You need to run this program as administrator", "Error: requires admin rights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
            games = new List<Game>();
            AddGame += addGame;
        }

        private void bSelectFolder_Click(object sender, EventArgs e)
        {
            clearList(null, null);

            dFolder.ShowDialog();
            Gpath = dFolder.SelectedPath;
            if (Gpath != null && Gpath != "")
            {
                lFolderName.Text = Gpath;

                Thread w = new Thread(new ThreadStart(refreshGameList));
                w.Start();
            }
        }

        private void addGame(Int32 id, String name, String path)
        {
            if (listBox.InvokeRequired)
            {
                AddGameHandler lba = new AddGameHandler(addGame);
                this.Invoke(lba, new object[] { id, name, path });
            }
            else
            {
                games.Add(new Game(id, name, path));
                listBox.Items.Add(name + "\t[" + Gpath + "]");
            }
        }

        private delegate void DisableButtonHandler();
        private void disableButton()
        {
            if (bCreateEntries.InvokeRequired)
            {
                DisableButtonHandler b = new DisableButtonHandler(disableButton);
                this.Invoke(b, null);
            }
            else
            {
                bClearList.Enabled = false;
                bSelectAll.Enabled = false;
                bCreateEntries.Enabled = false;
                bCreateEntries.Text = "Creating entries...";
            }
        }

        private delegate void EnableButtonHandler();
        private void enableButton()
        {
            if (bCreateEntries.InvokeRequired)
            {
                EnableButtonHandler b = new EnableButtonHandler(enableButton);
                this.Invoke(b, null);
            }
            else
            {
                bClearList.Enabled = true;
                bSelectAll.Enabled = true;
                bCreateEntries.Enabled = true;
                bCreateEntries.Text = "Create Registry entries";
            }
        }

        private Boolean isLibrary()
        {
            if(Directory.GetDirectories(Gpath, "SteamApps").Length == 1){
                Gpath +=  @"\SteamApps";
                return true;
            } else if(Directory.GetDirectories(Gpath, "common").Length == 1 && Directory.GetDirectories(Gpath, "downloading").Length == 1){
                return true;
            } else {
                return false;
            }
        }

        private void refreshGameList()
        {
            char[] sep = new char[]{'\t'};
            RegistryKey uninstallRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
            if (isLibrary())
            {
                // It looks like a steam library
                String[] files = Directory.GetFiles(Gpath, "*.acf");
                foreach(String f in files){
                    Int32 id=0; String name=null, path=null, line;
                    StreamReader sr = new StreamReader(f);
                    while((line = sr.ReadLine()) != null){
                        line = line.Trim().Replace("\"", "");
                        if (line.StartsWith("appid"))
                        {
                            string[] w= line.Split(sep);
                            id = Int32.Parse(line.Split(sep)[2]);
                            continue;
                        }
                        if (line.StartsWith("name"))
                        {
                            name = line.Split(sep)[2];
                            continue;
                        }
                        if (line.StartsWith("installdir"))
                        {
                            path = Gpath + @"\common\" + line.Split(sep)[2];
                            continue;
                        }
                    }
                    if(uninstallRoot.OpenSubKey("Steam App " + id) == null){
                        // Only add games with no key
                        AddGame(id, name, path);
                    }
                }
            }
        }
        
        private void bCreateEntries_Click(object sender, EventArgs e)
        {
            disableButton();
            List<Game> selectedGames = new List<Game>();
            foreach(Int32 index in listBox.CheckedIndices){
                selectedGames.Add(games[index]);
            }

            Thread w = new Thread(()=>createEntries(selectedGames));
            w.Start();
        }

        private void createEntries(List<Game> selectedGames)
        {
            // Get path to Steam.exe
            String steamPath = (String) Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam", false).GetValue("InstallPath");
            RegistryKey uninstallRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
            foreach (Game game in selectedGames)
            {
                // Make sure the key isn't already there
                if (uninstallRoot.OpenSubKey("Steam App " + game.id) == null)
                {
                    RegistryKey reg = uninstallRoot.CreateSubKey("Steam App " + game.id);
                    reg.SetValue("DisplayIcon", steamPath + @"\Steam.exe");
                    reg.SetValue("DisplayName", game.name);
                    reg.SetValue("HelpLink", "http://support.steampowered.com");
                    reg.SetValue("InstallLocation", game.path);
                    reg.SetValue("NoModify", 1);
                    reg.SetValue("NoRepair", 1);
                    reg.SetValue("Publisher", "Unknown");
                    reg.SetValue("UninstallString", "\"" + steamPath + "\\Steam.exe\" steam://uninstall/" + game.id);
                    reg.SetValue("URLInfoAbout", "http://store.steampowered.com/app/" + game.id);
                }
            }

            enableButton();
            MessageBox.Show("Registry entries created", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void selectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void clearList(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            games.Clear();
        }
    }

    public class Game
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public String path { get; set; }

        public Game(Int32 i, String n, String p) { id = i; name = n; path = p; }
    }
}
