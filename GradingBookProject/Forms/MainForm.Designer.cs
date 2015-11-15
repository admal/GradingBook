namespace GradingBookProject.Forms
{
    partial class MainForm
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
            this.listYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.tableMarks = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddYear = new System.Windows.Forms.Button();
            this.btnDeleteYear = new System.Windows.Forms.Button();
            this.btnEditYear = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listYear
            // 
            this.listYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listYear.FormattingEnabled = true;
            this.listYear.Location = new System.Drawing.Point(12, 69);
            this.listYear.Name = "listYear";
            this.listYear.Size = new System.Drawing.Size(121, 21);
            this.listYear.Sorted = true;
            this.listYear.TabIndex = 0;
            this.listYear.SelectedIndexChanged += new System.EventHandler(this.listYearSelected);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblYear.Location = new System.Drawing.Point(12, 44);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(170, 22);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Choose a semester:";
            // 
            // tableMarks
            // 
            this.tableMarks.AutoScroll = true;
            this.tableMarks.AutoSize = true;
            this.tableMarks.ColumnCount = 4;
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.45098F));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableMarks.Location = new System.Drawing.Point(12, 96);
            this.tableMarks.Name = "tableMarks";
            this.tableMarks.RowCount = 1;
            this.tableMarks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableMarks.Size = new System.Drawing.Size(579, 289);
            this.tableMarks.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.settingsToolStripMenuItem.Text = "Account";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.SettingsClick);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versionToolStripMenuItem.Text = "version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // btnAddYear
            // 
            this.btnAddYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddYear.Location = new System.Drawing.Point(140, 69);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(21, 21);
            this.btnAddYear.TabIndex = 4;
            this.btnAddYear.Text = "+";
            this.btnAddYear.UseVisualStyleBackColor = true;
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // btnDeleteYear
            // 
            this.btnDeleteYear.Location = new System.Drawing.Point(169, 69);
            this.btnDeleteYear.Name = "btnDeleteYear";
            this.btnDeleteYear.Size = new System.Drawing.Size(21, 21);
            this.btnDeleteYear.TabIndex = 5;
            this.btnDeleteYear.Text = "-";
            this.btnDeleteYear.UseVisualStyleBackColor = true;
            this.btnDeleteYear.Click += new System.EventHandler(this.btnDeleteYear_Click);
            // 
            // btnEditYear
            // 
            this.btnEditYear.Location = new System.Drawing.Point(197, 69);
            this.btnEditYear.Name = "btnEditYear";
            this.btnEditYear.Size = new System.Drawing.Size(21, 21);
            this.btnEditYear.TabIndex = 6;
            this.btnEditYear.Text = "E";
            this.btnEditYear.UseVisualStyleBackColor = true;
            this.btnEditYear.Click += new System.EventHandler(this.btnEditYear_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(12, 391);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(149, 36);
            this.btnAddSubject.TabIndex = 7;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(308, 44);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(603, 517);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnEditYear);
            this.Controls.Add(this.btnDeleteYear);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.tableMarks);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.listYear);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox listYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TableLayoutPanel tableMarks;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.Button btnAddYear;
        private System.Windows.Forms.Button btnDeleteYear;
        private System.Windows.Forms.Button btnEditYear;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}