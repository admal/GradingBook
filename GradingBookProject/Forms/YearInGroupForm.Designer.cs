namespace GradingBookProject.Forms
{
    partial class YearInGroupForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnDeleteYear = new System.Windows.Forms.Button();
            this.btnEditYear = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectsGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachermailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.btnDeleteYear);
            this.buttonPanel.Controls.Add(this.btnEditYear);
            this.buttonPanel.Controls.Add(this.btnAddSubject);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(620, 34);
            this.buttonPanel.TabIndex = 4;
            this.buttonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDeleteYear
            // 
            this.btnDeleteYear.Location = new System.Drawing.Point(174, 3);
            this.btnDeleteYear.Name = "btnDeleteYear";
            this.btnDeleteYear.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteYear.TabIndex = 4;
            this.btnDeleteYear.Text = "Delete year";
            this.btnDeleteYear.UseVisualStyleBackColor = true;
            this.btnDeleteYear.Click += new System.EventHandler(this.DeleteYearClick);
            // 
            // btnEditYear
            // 
            this.btnEditYear.Location = new System.Drawing.Point(93, 3);
            this.btnEditYear.Name = "btnEditYear";
            this.btnEditYear.Size = new System.Drawing.Size(75, 23);
            this.btnEditYear.TabIndex = 3;
            this.btnEditYear.Text = "Edit year";
            this.btnEditYear.UseVisualStyleBackColor = true;
            this.btnEditYear.Click += new System.EventHandler(this.EditYearClick);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(12, 3);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubject.TabIndex = 2;
            this.btnAddSubject.Text = "Add subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.usersGridView);
            this.dataPanel.Controls.Add(this.subjectsGridView);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 34);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(620, 413);
            this.dataPanel.TabIndex = 5;
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.AutoGenerateColumns = false;
            this.usersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn1,
            this.surnameDataGridViewTextBoxColumn});
            this.usersGridView.DataSource = this.usersBindingSource;
            this.usersGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usersGridView.Location = new System.Drawing.Point(0, 208);
            this.usersGridView.MultiSelect = false;
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGridView.Size = new System.Drawing.Size(620, 205);
            this.usersGridView.TabIndex = 1;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataSource = typeof(GradingBookProject.ViewModels.UsersViewModel);
            // 
            // subjectsGridView
            // 
            this.subjectsGridView.AllowUserToAddRows = false;
            this.subjectsGridView.AllowUserToDeleteRows = false;
            this.subjectsGridView.AutoGenerateColumns = false;
            this.subjectsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.subdescDataGridViewTextBoxColumn,
            this.teachermailDataGridViewTextBoxColumn});
            this.subjectsGridView.DataSource = this.subjectsBindingSource;
            this.subjectsGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.subjectsGridView.Location = new System.Drawing.Point(0, 0);
            this.subjectsGridView.MultiSelect = false;
            this.subjectsGridView.Name = "subjectsGridView";
            this.subjectsGridView.ReadOnly = true;
            this.subjectsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectsGridView.Size = new System.Drawing.Size(620, 202);
            this.subjectsGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subdescDataGridViewTextBoxColumn
            // 
            this.subdescDataGridViewTextBoxColumn.DataPropertyName = "sub_desc";
            this.subdescDataGridViewTextBoxColumn.HeaderText = "Subject description";
            this.subdescDataGridViewTextBoxColumn.Name = "subdescDataGridViewTextBoxColumn";
            this.subdescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teachermailDataGridViewTextBoxColumn
            // 
            this.teachermailDataGridViewTextBoxColumn.DataPropertyName = "teacher_mail";
            this.teachermailDataGridViewTextBoxColumn.HeaderText = "Teachers email address";
            this.teachermailDataGridViewTextBoxColumn.Name = "teachermailDataGridViewTextBoxColumn";
            this.teachermailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataSource = typeof(GradingBookProject.ViewModels.SubjectsViewModel);
            // 
            // YearInGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 447);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "YearInGroupForm";
            this.Text = "YearInGroupForm";
            this.buttonPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.DataGridView subjectsGridView;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teachermailDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDeleteYear;
        private System.Windows.Forms.Button btnEditYear;

    }
}