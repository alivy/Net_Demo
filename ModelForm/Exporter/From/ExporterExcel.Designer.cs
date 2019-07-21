namespace ModelForm.Exporter.From
{
    partial class ExporterExcel
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
            this.exl03 = new System.Windows.Forms.Button();
            this.exl07 = new System.Windows.Forms.Button();
            this.word03 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exl03
            // 
            this.exl03.Location = new System.Drawing.Point(92, 141);
            this.exl03.Name = "exl03";
            this.exl03.Size = new System.Drawing.Size(118, 23);
            this.exl03.TabIndex = 0;
            this.exl03.Text = "Excel2003导出";
            this.exl03.UseVisualStyleBackColor = true;
            this.exl03.Click += new System.EventHandler(this.exl03_Click);
            // 
            // exl07
            // 
            this.exl07.Location = new System.Drawing.Point(92, 190);
            this.exl07.Name = "exl07";
            this.exl07.Size = new System.Drawing.Size(118, 23);
            this.exl07.TabIndex = 1;
            this.exl07.Text = "Excel2007导出";
            this.exl07.UseVisualStyleBackColor = true;
            // 
            // word03
            // 
            this.word03.Location = new System.Drawing.Point(92, 238);
            this.word03.Name = "word03";
            this.word03.Size = new System.Drawing.Size(118, 23);
            this.word03.TabIndex = 2;
            this.word03.Text = "word2003导出";
            this.word03.UseVisualStyleBackColor = true;
            // 
            // ExporterExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.word03);
            this.Controls.Add(this.exl07);
            this.Controls.Add(this.exl03);
            this.Name = "ExporterExcel";
            this.Text = "Excel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exl03;
        private System.Windows.Forms.Button exl07;
        private System.Windows.Forms.Button word03;
    }
}