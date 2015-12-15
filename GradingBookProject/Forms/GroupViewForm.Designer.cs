namespace GradingBookProject.Forms
{
    partial class GroupViewForm
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
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnAddYear = new System.Windows.Forms.Button();
            this.tableYears = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDesc
            // 
            this.tbDesc.Enabled = false;
            this.tbDesc.Location = new System.Drawing.Point(12, 12);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(197, 131);
            this.tbDesc.TabIndex = 0;
            this.tbDesc.Text = "Description....";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCreator.Location = new System.Drawing.Point(456, 15);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(62, 18);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "Creator:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUsername.Location = new System.Drawing.Point(524, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(74, 18);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "username";
            // 
            // btnAddYear
            // 
            this.btnAddYear.Enabled = false;
            this.btnAddYear.Location = new System.Drawing.Point(523, 47);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(75, 23);
            this.btnAddYear.TabIndex = 3;
            this.btnAddYear.Text = "Add year";
            this.btnAddYear.UseVisualStyleBackColor = true;
            // 
            // tableYears
            // 
            this.tableYears.ColumnCount = 3;
            this.tableYears.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableYears.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableYears.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableYears.Location = new System.Drawing.Point(12, 149);
            this.tableYears.Name = "tableYears";
            this.tableYears.RowCount = 1;
            this.tableYears.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableYears.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableYears.Size = new System.Drawing.Size(586, 208);
            this.tableYears.TabIndex = 4;
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(523, 76);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(75, 23);
            this.btnLeave.TabIndex = 5;
            this.btnLeave.Text = "Leave group";
            this.btnLeave.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(523, 363);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // GroupViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 398);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.tableYears);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.tbDesc);
            this.Name = "GroupViewForm";
            this.Text = "GroupTitle";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnAddYear;
        private System.Windows.Forms.TableLayoutPanel tableYears;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}