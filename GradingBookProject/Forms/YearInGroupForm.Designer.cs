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
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.subjectsGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachermailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subdescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.btnAddSubject);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(620, 34);
            this.buttonPanel.TabIndex = 4;
            this.buttonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usersGridView.Location = new System.Drawing.Point(0, 208);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.Size = new System.Drawing.Size(620, 205);
            this.usersGridView.TabIndex = 1;
            // 
            // subjectsGridView
            // 
            this.subjectsGridView.AllowUserToAddRows = false;
            this.subjectsGridView.AllowUserToDeleteRows = false;
            this.subjectsGridView.AutoGenerateColumns = false;
            this.subjectsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.teachermailDataGridViewTextBoxColumn,
            this.subdescDataGridViewTextBoxColumn});
            this.subjectsGridView.DataSource = this.subjectsViewModelBindingSource;
            this.subjectsGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.subjectsGridView.Location = new System.Drawing.Point(0, 0);
            this.subjectsGridView.Name = "subjectsGridView";
            this.subjectsGridView.ReadOnly = true;
            this.subjectsGridView.Size = new System.Drawing.Size(620, 202);
            this.subjectsGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teachermailDataGridViewTextBoxColumn
            // 
            this.teachermailDataGridViewTextBoxColumn.DataPropertyName = "teacher_mail";
            this.teachermailDataGridViewTextBoxColumn.HeaderText = "Teacher\'s mail";
            this.teachermailDataGridViewTextBoxColumn.Name = "teachermailDataGridViewTextBoxColumn";
            this.teachermailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subdescDataGridViewTextBoxColumn
            // 
            this.subdescDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subdescDataGridViewTextBoxColumn.DataPropertyName = "sub_desc";
            this.subdescDataGridViewTextBoxColumn.HeaderText = "Description";
            this.subdescDataGridViewTextBoxColumn.Name = "subdescDataGridViewTextBoxColumn";
            this.subdescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subjectsViewModelBindingSource
            // 
            this.subjectsViewModelBindingSource.DataSource = typeof(GradingBookProject.ViewModels.SubjectsViewModel);
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
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.DataGridView subjectsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teachermailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subdescDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource subjectsViewModelBindingSource;
        private System.Windows.Forms.Button btnAddSubject;

    }
}