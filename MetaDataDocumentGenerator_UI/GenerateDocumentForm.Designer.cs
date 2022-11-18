
namespace MetaDataDocumentGenerator_UI
{
    partial class GenerateDocumentForm
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
            this.GenerateDoument = new System.Windows.Forms.Button();
            this.OutputFolderPathLabel = new System.Windows.Forms.Label();
            this.OutputFileBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.OpenFileBrowseDialog = new System.Windows.Forms.Button();
            this.AutoGenerateFieldOutputLabel = new System.Windows.Forms.Label();
            this.AutoGenerateFieldOutputFg = new System.Windows.Forms.CheckBox();
            this.OutputFileNameLabel = new System.Windows.Forms.Label();
            this.OutputFileName = new System.Windows.Forms.TextBox();
            this.FileExtensionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateDoument
            // 
            this.GenerateDoument.Location = new System.Drawing.Point(564, 179);
            this.GenerateDoument.Name = "GenerateDoument";
            this.GenerateDoument.Size = new System.Drawing.Size(78, 23);
            this.GenerateDoument.TabIndex = 0;
            this.GenerateDoument.Text = "出力";
            this.GenerateDoument.UseVisualStyleBackColor = true;
            this.GenerateDoument.Click += new System.EventHandler(this.GenerateDoument_Click);
            // 
            // OutputFolderPathLabel
            // 
            this.OutputFolderPathLabel.AutoSize = true;
            this.OutputFolderPathLabel.Location = new System.Drawing.Point(103, 53);
            this.OutputFolderPathLabel.Name = "OutputFolderPathLabel";
            this.OutputFolderPathLabel.Size = new System.Drawing.Size(63, 12);
            this.OutputFolderPathLabel.TabIndex = 1;
            this.OutputFolderPathLabel.Text = "出力ファイル";
            // 
            // OutputFileBrowserDialog
            // 
            this.OutputFileBrowserDialog.Description = "出力ファイルを指定してください。";
            this.OutputFileBrowserDialog.SelectedPath = "C:\\";
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(195, 50);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(422, 19);
            this.FolderPath.TabIndex = 2;
            // 
            // OpenFileBrowseDialog
            // 
            this.OpenFileBrowseDialog.Location = new System.Drawing.Point(641, 48);
            this.OpenFileBrowseDialog.Name = "OpenFileBrowseDialog";
            this.OpenFileBrowseDialog.Size = new System.Drawing.Size(35, 23);
            this.OpenFileBrowseDialog.TabIndex = 3;
            this.OpenFileBrowseDialog.Text = "...";
            this.OpenFileBrowseDialog.UseVisualStyleBackColor = true;
            this.OpenFileBrowseDialog.Click += new System.EventHandler(this.OpenFileBrowseDialog_Click);
            // 
            // AutoGenerateFieldOutputLabel
            // 
            this.AutoGenerateFieldOutputLabel.AutoSize = true;
            this.AutoGenerateFieldOutputLabel.Location = new System.Drawing.Point(35, 141);
            this.AutoGenerateFieldOutputLabel.Name = "AutoGenerateFieldOutputLabel";
            this.AutoGenerateFieldOutputLabel.Size = new System.Drawing.Size(131, 12);
            this.AutoGenerateFieldOutputLabel.TabIndex = 1;
            this.AutoGenerateFieldOutputLabel.Text = "自動生成フィールドの出力";
            // 
            // AutoGenerateFieldOutputFg
            // 
            this.AutoGenerateFieldOutputFg.AutoSize = true;
            this.AutoGenerateFieldOutputFg.Location = new System.Drawing.Point(195, 141);
            this.AutoGenerateFieldOutputFg.Name = "AutoGenerateFieldOutputFg";
            this.AutoGenerateFieldOutputFg.Size = new System.Drawing.Size(15, 14);
            this.AutoGenerateFieldOutputFg.TabIndex = 4;
            this.AutoGenerateFieldOutputFg.UseVisualStyleBackColor = true;
            // 
            // OutputFileNameLabel
            // 
            this.OutputFileNameLabel.AutoSize = true;
            this.OutputFileNameLabel.Location = new System.Drawing.Point(91, 98);
            this.OutputFileNameLabel.Name = "OutputFileNameLabel";
            this.OutputFileNameLabel.Size = new System.Drawing.Size(75, 12);
            this.OutputFileNameLabel.TabIndex = 1;
            this.OutputFileNameLabel.Text = "出力ファイル名";
            // 
            // OutputFileName
            // 
            this.OutputFileName.Location = new System.Drawing.Point(195, 95);
            this.OutputFileName.Name = "OutputFileName";
            this.OutputFileName.Size = new System.Drawing.Size(422, 19);
            this.OutputFileName.TabIndex = 2;
            // 
            // FileExtensionLabel
            // 
            this.FileExtensionLabel.AutoSize = true;
            this.FileExtensionLabel.Location = new System.Drawing.Point(618, 98);
            this.FileExtensionLabel.Name = "FileExtensionLabel";
            this.FileExtensionLabel.Size = new System.Drawing.Size(28, 12);
            this.FileExtensionLabel.TabIndex = 1;
            this.FileExtensionLabel.Text = ".xlsx";
            // 
            // GenerateDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 260);
            this.Controls.Add(this.AutoGenerateFieldOutputFg);
            this.Controls.Add(this.OpenFileBrowseDialog);
            this.Controls.Add(this.OutputFileName);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.FileExtensionLabel);
            this.Controls.Add(this.OutputFileNameLabel);
            this.Controls.Add(this.AutoGenerateFieldOutputLabel);
            this.Controls.Add(this.OutputFolderPathLabel);
            this.Controls.Add(this.GenerateDoument);
            this.Name = "GenerateDocumentForm";
            this.Text = "GenerateDocumentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateDoument;
        private System.Windows.Forms.Label OutputFolderPathLabel;
        private System.Windows.Forms.FolderBrowserDialog OutputFileBrowserDialog;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button OpenFileBrowseDialog;
        private System.Windows.Forms.Label AutoGenerateFieldOutputLabel;
        private System.Windows.Forms.CheckBox AutoGenerateFieldOutputFg;
        private System.Windows.Forms.Label OutputFileNameLabel;
        private System.Windows.Forms.TextBox OutputFileName;
        private System.Windows.Forms.Label FileExtensionLabel;
    }
}