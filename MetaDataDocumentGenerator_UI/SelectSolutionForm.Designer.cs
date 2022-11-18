
namespace MetaDataDocumentGenerator_UI
{
    partial class SelectSolutionForm
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
            this.SolutionList = new System.Windows.Forms.ListView();
            this.DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectSolutionOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SolutionList
            // 
            this.SolutionList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.SolutionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SolutionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayName,
            this.UniqueName});
            this.SolutionList.FullRowSelect = true;
            this.SolutionList.GridLines = true;
            this.SolutionList.HideSelection = false;
            this.SolutionList.Location = new System.Drawing.Point(77, 103);
            this.SolutionList.MultiSelect = false;
            this.SolutionList.Name = "SolutionList";
            this.SolutionList.Size = new System.Drawing.Size(650, 245);
            this.SolutionList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.SolutionList.TabIndex = 0;
            this.SolutionList.UseCompatibleStateImageBehavior = false;
            this.SolutionList.View = System.Windows.Forms.View.Details;
            // 
            // DisplayName
            // 
            this.DisplayName.Text = "表示名";
            this.DisplayName.Width = 350;
            // 
            // UniqueName
            // 
            this.UniqueName.Text = "物理名";
            this.UniqueName.Width = 300;
            // 
            // SelectSolutionOk
            // 
            this.SelectSolutionOk.Location = new System.Drawing.Point(682, 398);
            this.SelectSolutionOk.Name = "SelectSolutionOk";
            this.SelectSolutionOk.Size = new System.Drawing.Size(75, 23);
            this.SelectSolutionOk.TabIndex = 1;
            this.SelectSolutionOk.Text = "OK";
            this.SelectSolutionOk.UseVisualStyleBackColor = true;
            this.SelectSolutionOk.Click += new System.EventHandler(this.SelectSolutionOk_Click);
            // 
            // SelectSolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectSolutionOk);
            this.Controls.Add(this.SolutionList);
            this.Name = "SelectSolutionForm";
            this.Text = "SelectSolution";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SolutionList;
        private System.Windows.Forms.ColumnHeader DisplayName;
        private System.Windows.Forms.ColumnHeader UniqueName;
        private System.Windows.Forms.Button SelectSolutionOk;
    }
}