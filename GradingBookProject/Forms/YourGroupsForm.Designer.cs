namespace GradingBookProject.Forms
{
    partial class YourGroupsForm
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupsGridView = new System.Windows.Forms.DataGridView();
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditGridView = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 227);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(96, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create group";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.NewGroupClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(114, 227);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BackClick);
            // 
            // groupsGridView
            // 
            this.groupsGridView.AllowUserToAddRows = false;
            this.groupsGridView.AllowUserToDeleteRows = false;
            this.groupsGridView.AutoGenerateColumns = false;
            this.groupsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.id,
            this.created_at,
            this.btnEditGridView});
            this.groupsGridView.DataSource = this.groupsBindingSource;
            this.groupsGridView.Location = new System.Drawing.Point(12, 12);
            this.groupsGridView.Name = "groupsGridView";
            this.groupsGridView.ReadOnly = true;
            this.groupsGridView.Size = new System.Drawing.Size(491, 150);
            this.groupsGridView.TabIndex = 3;
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataSource = typeof(GradingBookProject.ViewModels.GroupsViewModel);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // created_at
            // 
            this.created_at.DataPropertyName = "created_at";
            this.created_at.HeaderText = "Created at";
            this.created_at.Name = "created_at";
            this.created_at.ReadOnly = true;
            // 
            // btnEditGridView
            // 
            this.btnEditGridView.HeaderText = "Edit";
            this.btnEditGridView.Name = "btnEditGridView";
            this.btnEditGridView.ReadOnly = true;
            // 
            // YourGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 262);
            this.Controls.Add(this.groupsGridView);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCreate);
            this.Name = "YourGroupsForm";
            this.Text = "Your groups";
            ((System.ComponentModel.ISupportInitialize)(this.groupsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView groupsGridView;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_at;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditGridView;
    }
}