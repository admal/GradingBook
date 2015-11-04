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
            this.SuspendLayout();
            // 
            // listYear
            // 
            this.listYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listYear.FormattingEnabled = true;
            this.listYear.Items.AddRange(new object[] {
            "2014",
            "2015"});
            this.listYear.Location = new System.Drawing.Point(12, 34);
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
            this.lblYear.Location = new System.Drawing.Point(12, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(132, 22);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Choose a year:";
            // 
            // tableMarks
            // 
            this.tableMarks.ColumnCount = 2;
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.82353F));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.17647F));
            this.tableMarks.Location = new System.Drawing.Point(12, 61);
            this.tableMarks.Name = "tableMarks";
            this.tableMarks.RowCount = 2;
            this.tableMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMarks.Size = new System.Drawing.Size(510, 444);
            this.tableMarks.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 517);
            this.Controls.Add(this.tableMarks);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.listYear);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox listYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TableLayoutPanel tableMarks;
    }
}