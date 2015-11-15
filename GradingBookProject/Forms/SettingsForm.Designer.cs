namespace GradingBookProject.Forms
{
    partial class SettingsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.credentialsPanel = new System.Windows.Forms.Panel();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbConfPasswd = new System.Windows.Forms.TextBox();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.lblConfPasswd = new System.Windows.Forms.Label();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.credentialsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(126, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User settings";
            // 
            // credentialsPanel
            // 
            this.credentialsPanel.Controls.Add(this.tbSurname);
            this.credentialsPanel.Controls.Add(this.tbName);
            this.credentialsPanel.Controls.Add(this.tbEmail);
            this.credentialsPanel.Controls.Add(this.tbUsername);
            this.credentialsPanel.Controls.Add(this.lblSurname);
            this.credentialsPanel.Controls.Add(this.lblEmail);
            this.credentialsPanel.Controls.Add(this.lblName);
            this.credentialsPanel.Controls.Add(this.lblUsername);
            this.credentialsPanel.Location = new System.Drawing.Point(40, 50);
            this.credentialsPanel.Name = "credentialsPanel";
            this.credentialsPanel.Size = new System.Drawing.Size(200, 109);
            this.credentialsPanel.TabIndex = 6;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(108, 86);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(89, 20);
            this.tbSurname.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(108, 61);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(89, 20);
            this.tbName.TabIndex = 6;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(108, 35);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(89, 20);
            this.tbEmail.TabIndex = 5;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(108, 9);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(89, 20);
            this.tbUsername.TabIndex = 4;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(6, 86);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(90, 13);
            this.lblSurname.TabIndex = 3;
            this.lblSurname.Text = "Change surname:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 38);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(74, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Change email:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Change name:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(96, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Change username:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbConfPasswd);
            this.panel1.Controls.Add(this.tbPasswd);
            this.panel1.Controls.Add(this.lblConfPasswd);
            this.panel1.Controls.Add(this.lblPasswd);
            this.panel1.Location = new System.Drawing.Point(40, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 58);
            this.panel1.TabIndex = 7;
            // 
            // tbConfPasswd
            // 
            this.tbConfPasswd.Location = new System.Drawing.Point(108, 32);
            this.tbConfPasswd.Name = "tbConfPasswd";
            this.tbConfPasswd.Size = new System.Drawing.Size(89, 20);
            this.tbConfPasswd.TabIndex = 9;
            // 
            // tbPasswd
            // 
            this.tbPasswd.Location = new System.Drawing.Point(107, 7);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.Size = new System.Drawing.Size(89, 20);
            this.tbPasswd.TabIndex = 8;
            // 
            // lblConfPasswd
            // 
            this.lblConfPasswd.AutoSize = true;
            this.lblConfPasswd.Location = new System.Drawing.Point(6, 35);
            this.lblConfPasswd.Name = "lblConfPasswd";
            this.lblConfPasswd.Size = new System.Drawing.Size(93, 13);
            this.lblConfPasswd.TabIndex = 1;
            this.lblConfPasswd.Text = "Confirm password:";
            // 
            // lblPasswd
            // 
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.Location = new System.Drawing.Point(6, 10);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(95, 13);
            this.lblPasswd.TabIndex = 0;
            this.lblPasswd.Text = "Change password:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveChangesClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.credentialsPanel);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.credentialsPanel.ResumeLayout(false);
            this.credentialsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel credentialsPanel;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbConfPasswd;
        private System.Windows.Forms.TextBox tbPasswd;
        private System.Windows.Forms.Label lblConfPasswd;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}