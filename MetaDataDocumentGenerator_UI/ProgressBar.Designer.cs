
namespace MetaDataDocumentGenerator_UI
{
    partial class ProgressBar
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
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressPercent = new System.Windows.Forms.Label();
            this.ProgressPercentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(109, 44);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(617, 36);
            this.ProgressBar1.TabIndex = 0;
            // 
            // ProgressPercent
            // 
            this.ProgressPercent.AutoSize = true;
            this.ProgressPercent.Location = new System.Drawing.Point(33, 106);
            this.ProgressPercent.Name = "ProgressPercent";
            this.ProgressPercent.Size = new System.Drawing.Size(0, 12);
            this.ProgressPercent.TabIndex = 1;
            // 
            // ProgressPercentLabel
            // 
            this.ProgressPercentLabel.AutoSize = true;
            this.ProgressPercentLabel.Location = new System.Drawing.Point(56, 56);
            this.ProgressPercentLabel.Name = "ProgressPercentLabel";
            this.ProgressPercentLabel.Size = new System.Drawing.Size(17, 12);
            this.ProgressPercentLabel.TabIndex = 2;
            this.ProgressPercentLabel.Text = "0%";
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 124);
            this.Controls.Add(this.ProgressPercentLabel);
            this.Controls.Add(this.ProgressPercent);
            this.Controls.Add(this.ProgressBar1);
            this.Name = "ProgressBar";
            this.Text = "進行状況";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ProgressPercent;
        public System.Windows.Forms.Label ProgressPercentLabel;
        public System.Windows.Forms.ProgressBar ProgressBar1;
    }
}