namespace SteamRegistryCreator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSelectFolder = new System.Windows.Forms.Button();
            this.lFolderName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.CheckedListBox();
            this.bCreateEntries = new System.Windows.Forms.Button();
            this.dFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.bClearList = new System.Windows.Forms.Button();
            this.bSelectAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSelectFolder);
            this.groupBox1.Controls.Add(this.lFolderName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bSelectFolder
            // 
            this.bSelectFolder.Location = new System.Drawing.Point(517, 11);
            this.bSelectFolder.Name = "bSelectFolder";
            this.bSelectFolder.Size = new System.Drawing.Size(97, 23);
            this.bSelectFolder.TabIndex = 2;
            this.bSelectFolder.Text = "Select folder...";
            this.bSelectFolder.UseVisualStyleBackColor = true;
            this.bSelectFolder.Click += new System.EventHandler(this.bSelectFolder_Click);
            // 
            // lFolderName
            // 
            this.lFolderName.AutoSize = true;
            this.lFolderName.Location = new System.Drawing.Point(156, 16);
            this.lFolderName.Name = "lFolderName";
            this.lFolderName.Size = new System.Drawing.Size(84, 13);
            this.lFolderName.TabIndex = 1;
            this.lFolderName.Text = "Select a folder...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Steam library:";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(10, 62);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(645, 274);
            this.listBox.TabIndex = 1;
            // 
            // bCreateEntries
            // 
            this.bCreateEntries.Location = new System.Drawing.Point(10, 377);
            this.bCreateEntries.Name = "bCreateEntries";
            this.bCreateEntries.Size = new System.Drawing.Size(644, 29);
            this.bCreateEntries.TabIndex = 2;
            this.bCreateEntries.Text = "Create Registry entries";
            this.bCreateEntries.UseVisualStyleBackColor = true;
            this.bCreateEntries.Click += new System.EventHandler(this.bCreateEntries_Click);
            // 
            // bClearList
            // 
            this.bClearList.Location = new System.Drawing.Point(10, 342);
            this.bClearList.Name = "bClearList";
            this.bClearList.Size = new System.Drawing.Size(315, 29);
            this.bClearList.TabIndex = 3;
            this.bClearList.Text = "Clear list";
            this.bClearList.UseVisualStyleBackColor = true;
            this.bClearList.Click += new System.EventHandler(this.clearList);
            // 
            // bSelectAll
            // 
            this.bSelectAll.Location = new System.Drawing.Point(339, 342);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(315, 29);
            this.bSelectAll.TabIndex = 4;
            this.bSelectAll.Text = "Select all";
            this.bSelectAll.UseVisualStyleBackColor = true;
            this.bSelectAll.Click += new System.EventHandler(this.selectAll);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 418);
            this.Controls.Add(this.bSelectAll);
            this.Controls.Add(this.bClearList);
            this.Controls.Add(this.bCreateEntries);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Steam Registry Entries Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSelectFolder;
        private System.Windows.Forms.Label lFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listBox;
        private System.Windows.Forms.Button bCreateEntries;
        private System.Windows.Forms.FolderBrowserDialog dFolder;
        private System.Windows.Forms.Button bClearList;
        private System.Windows.Forms.Button bSelectAll;
    }
}

