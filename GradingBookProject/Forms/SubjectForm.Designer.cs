namespace GradingBookProject.Forms
{
    partial class SubjectForm
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
            this.btnSubjectCancel = new System.Windows.Forms.Button();
            this.txtSubjectDesc = new System.Windows.Forms.RichTextBox();
            this.lSubjectDesc = new System.Windows.Forms.Label();
            this.txtSubjectEmail = new System.Windows.Forms.TextBox();
            this.lSubjectEmail = new System.Windows.Forms.Label();
            this.lSubjectName = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.btnSubjectSave = new System.Windows.Forms.Button();
            this.btnSubjectDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubjectCancel
            // 
            this.btnSubjectCancel.Location = new System.Drawing.Point(205, 255);
            this.btnSubjectCancel.Name = "btnSubjectCancel";
            this.btnSubjectCancel.Size = new System.Drawing.Size(107, 44);
            this.btnSubjectCancel.TabIndex = 18;
            this.btnSubjectCancel.Text = "Exit";
            this.btnSubjectCancel.UseVisualStyleBackColor = true;
            this.btnSubjectCancel.Click += new System.EventHandler(this.btnSubjectCancel_Click);
            // 
            // txtSubjectDesc
            // 
            this.txtSubjectDesc.Location = new System.Drawing.Point(17, 143);
            this.txtSubjectDesc.Name = "txtSubjectDesc";
            this.txtSubjectDesc.Size = new System.Drawing.Size(244, 96);
            this.txtSubjectDesc.TabIndex = 17;
            this.txtSubjectDesc.Text = "";
            // 
            // lSubjectDesc
            // 
            this.lSubjectDesc.AutoSize = true;
            this.lSubjectDesc.Location = new System.Drawing.Point(14, 127);
            this.lSubjectDesc.Name = "lSubjectDesc";
            this.lSubjectDesc.Size = new System.Drawing.Size(102, 13);
            this.lSubjectDesc.TabIndex = 16;
            this.lSubjectDesc.Text = "Subject Description:";
            // 
            // txtSubjectEmail
            // 
            this.txtSubjectEmail.Location = new System.Drawing.Point(16, 85);
            this.txtSubjectEmail.Name = "txtSubjectEmail";
            this.txtSubjectEmail.Size = new System.Drawing.Size(163, 20);
            this.txtSubjectEmail.TabIndex = 13;
            // 
            // lSubjectEmail
            // 
            this.lSubjectEmail.AutoSize = true;
            this.lSubjectEmail.Location = new System.Drawing.Point(13, 69);
            this.lSubjectEmail.Name = "lSubjectEmail";
            this.lSubjectEmail.Size = new System.Drawing.Size(119, 13);
            this.lSubjectEmail.TabIndex = 12;
            this.lSubjectEmail.Text = "Subject\'s teacher email:";
            // 
            // lSubjectName
            // 
            this.lSubjectName.AutoSize = true;
            this.lSubjectName.Location = new System.Drawing.Point(13, 21);
            this.lSubjectName.Name = "lSubjectName";
            this.lSubjectName.Size = new System.Drawing.Size(75, 13);
            this.lSubjectName.TabIndex = 11;
            this.lSubjectName.Text = "Subject name:";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(16, 37);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(163, 20);
            this.txtSubjectName.TabIndex = 10;
            // 
            // btnSubjectSave
            // 
            this.btnSubjectSave.Location = new System.Drawing.Point(3, 255);
            this.btnSubjectSave.Name = "btnSubjectSave";
            this.btnSubjectSave.Size = new System.Drawing.Size(104, 44);
            this.btnSubjectSave.TabIndex = 19;
            this.btnSubjectSave.Text = "Save";
            this.btnSubjectSave.UseVisualStyleBackColor = true;
            this.btnSubjectSave.Click += new System.EventHandler(this.btnSubjectSave_Click);
            // 
            // btnSubjectDelete
            // 
            this.btnSubjectDelete.Location = new System.Drawing.Point(113, 255);
            this.btnSubjectDelete.Name = "btnSubjectDelete";
            this.btnSubjectDelete.Size = new System.Drawing.Size(86, 44);
            this.btnSubjectDelete.TabIndex = 20;
            this.btnSubjectDelete.Text = "Delete";
            this.btnSubjectDelete.UseVisualStyleBackColor = true;
            this.btnSubjectDelete.Click += new System.EventHandler(this.btnSubjectDelete_Click);
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 320);
            this.Controls.Add(this.btnSubjectDelete);
            this.Controls.Add(this.btnSubjectSave);
            this.Controls.Add(this.btnSubjectCancel);
            this.Controls.Add(this.txtSubjectDesc);
            this.Controls.Add(this.lSubjectDesc);
            this.Controls.Add(this.txtSubjectEmail);
            this.Controls.Add(this.lSubjectEmail);
            this.Controls.Add(this.lSubjectName);
            this.Controls.Add(this.txtSubjectName);
            this.Name = "SubjectForm";
            this.Text = "SubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubjectCancel;
        private System.Windows.Forms.RichTextBox txtSubjectDesc;
        private System.Windows.Forms.Label lSubjectDesc;
        private System.Windows.Forms.TextBox txtSubjectEmail;
        private System.Windows.Forms.Label lSubjectEmail;
        private System.Windows.Forms.Label lSubjectName;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Button btnSubjectSave;
        private System.Windows.Forms.Button btnSubjectDelete;

    }
}