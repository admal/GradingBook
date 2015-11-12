namespace GradingBookProject.Forms
{
    partial class YearForm
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
            this.txtYearName = new System.Windows.Forms.TextBox();
            this.lYearName = new System.Windows.Forms.Label();
            this.lYearStart = new System.Windows.Forms.Label();
            this.txtYearStart = new System.Windows.Forms.TextBox();
            this.lYearEnd = new System.Windows.Forms.Label();
            this.txtYearEnd = new System.Windows.Forms.TextBox();
            this.lYearDesc = new System.Windows.Forms.Label();
            this.txtYearDesc = new System.Windows.Forms.RichTextBox();
            this.btnYearSave = new System.Windows.Forms.Button();
            this.btnYearCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtYearName
            // 
            this.txtYearName.Location = new System.Drawing.Point(12, 29);
            this.txtYearName.Name = "txtYearName";
            this.txtYearName.Size = new System.Drawing.Size(163, 20);
            this.txtYearName.TabIndex = 0;
            // 
            // lYearName
            // 
            this.lYearName.AutoSize = true;
            this.lYearName.Location = new System.Drawing.Point(9, 13);
            this.lYearName.Name = "lYearName";
            this.lYearName.Size = new System.Drawing.Size(61, 13);
            this.lYearName.TabIndex = 1;
            this.lYearName.Text = "Year name:";
            // 
            // lYearStart
            // 
            this.lYearStart.AutoSize = true;
            this.lYearStart.Location = new System.Drawing.Point(9, 52);
            this.lYearStart.Name = "lYearStart";
            this.lYearStart.Size = new System.Drawing.Size(79, 13);
            this.lYearStart.TabIndex = 2;
            this.lYearStart.Text = "Year start date:";
            // 
            // txtYearStart
            // 
            this.txtYearStart.Location = new System.Drawing.Point(12, 68);
            this.txtYearStart.Name = "txtYearStart";
            this.txtYearStart.Size = new System.Drawing.Size(163, 20);
            this.txtYearStart.TabIndex = 3;
            // 
            // lYearEnd
            // 
            this.lYearEnd.AutoSize = true;
            this.lYearEnd.Location = new System.Drawing.Point(9, 91);
            this.lYearEnd.Name = "lYearEnd";
            this.lYearEnd.Size = new System.Drawing.Size(77, 13);
            this.lYearEnd.TabIndex = 4;
            this.lYearEnd.Text = "Year end date:";
            // 
            // txtYearEnd
            // 
            this.txtYearEnd.Location = new System.Drawing.Point(12, 108);
            this.txtYearEnd.Name = "txtYearEnd";
            this.txtYearEnd.Size = new System.Drawing.Size(163, 20);
            this.txtYearEnd.TabIndex = 5;
            // 
            // lYearDesc
            // 
            this.lYearDesc.AutoSize = true;
            this.lYearDesc.Location = new System.Drawing.Point(9, 131);
            this.lYearDesc.Name = "lYearDesc";
            this.lYearDesc.Size = new System.Drawing.Size(88, 13);
            this.lYearDesc.TabIndex = 6;
            this.lYearDesc.Text = "Year Description:";
            // 
            // txtYearDesc
            // 
            this.txtYearDesc.Location = new System.Drawing.Point(13, 148);
            this.txtYearDesc.Name = "txtYearDesc";
            this.txtYearDesc.Size = new System.Drawing.Size(244, 96);
            this.txtYearDesc.TabIndex = 7;
            this.txtYearDesc.Text = "";
            // 
            // btnYearSave
            // 
            this.btnYearSave.Location = new System.Drawing.Point(-1, 277);
            this.btnYearSave.Name = "btnYearSave";
            this.btnYearSave.Size = new System.Drawing.Size(151, 44);
            this.btnYearSave.TabIndex = 8;
            this.btnYearSave.Text = "Save";
            this.btnYearSave.UseVisualStyleBackColor = true;
            this.btnYearSave.Click += new System.EventHandler(this.btnYearSave_Click);
            // 
            // btnYearCancel
            // 
            this.btnYearCancel.Location = new System.Drawing.Point(156, 277);
            this.btnYearCancel.Name = "btnYearCancel";
            this.btnYearCancel.Size = new System.Drawing.Size(151, 44);
            this.btnYearCancel.TabIndex = 9;
            this.btnYearCancel.Text = "Cancel";
            this.btnYearCancel.UseVisualStyleBackColor = true;
            // 
            // YearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 333);
            this.Controls.Add(this.btnYearCancel);
            this.Controls.Add(this.btnYearSave);
            this.Controls.Add(this.txtYearDesc);
            this.Controls.Add(this.lYearDesc);
            this.Controls.Add(this.txtYearEnd);
            this.Controls.Add(this.lYearEnd);
            this.Controls.Add(this.txtYearStart);
            this.Controls.Add(this.lYearStart);
            this.Controls.Add(this.lYearName);
            this.Controls.Add(this.txtYearName);
            this.Name = "YearForm";
            this.Text = "YearForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtYearName;
        private System.Windows.Forms.Label lYearName;
        private System.Windows.Forms.Label lYearStart;
        private System.Windows.Forms.TextBox txtYearStart;
        private System.Windows.Forms.Label lYearEnd;
        private System.Windows.Forms.TextBox txtYearEnd;
        private System.Windows.Forms.Label lYearDesc;
        private System.Windows.Forms.RichTextBox txtYearDesc;
        private System.Windows.Forms.Button btnYearSave;
        private System.Windows.Forms.Button btnYearCancel;

    }
}