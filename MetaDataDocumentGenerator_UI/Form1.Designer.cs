
namespace MetaDataDocumentGenerator_UI
{
    partial class LoginForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Login = new System.Windows.Forms.Button();
            this.LoginUserName = new System.Windows.Forms.TextBox();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.EnvironmentUrl = new System.Windows.Forms.TextBox();
            this.EnvironmentUrlLabel = new System.Windows.Forms.Label();
            this.LoginUserNameLabel = new System.Windows.Forms.Label();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Login.Location = new System.Drawing.Point(563, 183);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // LoginUserName
            // 
            this.LoginUserName.Location = new System.Drawing.Point(114, 81);
            this.LoginUserName.Name = "LoginUserName";
            this.LoginUserName.Size = new System.Drawing.Size(412, 19);
            this.LoginUserName.TabIndex = 1;
            this.LoginUserName.Tag = "";
            // 
            // LoginPassword
            // 
            this.LoginPassword.Location = new System.Drawing.Point(114, 123);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.PasswordChar = '*';
            this.LoginPassword.Size = new System.Drawing.Size(412, 19);
            this.LoginPassword.TabIndex = 2;
            // 
            // EnvironmentUrl
            // 
            this.EnvironmentUrl.Location = new System.Drawing.Point(114, 34);
            this.EnvironmentUrl.Name = "EnvironmentUrl";
            this.EnvironmentUrl.Size = new System.Drawing.Size(412, 19);
            this.EnvironmentUrl.TabIndex = 1;
            this.EnvironmentUrl.Tag = "";
            // 
            // EnvironmentUrlLabel
            // 
            this.EnvironmentUrlLabel.AutoSize = true;
            this.EnvironmentUrlLabel.Location = new System.Drawing.Point(36, 37);
            this.EnvironmentUrlLabel.Name = "EnvironmentUrlLabel";
            this.EnvironmentUrlLabel.Size = new System.Drawing.Size(51, 12);
            this.EnvironmentUrlLabel.TabIndex = 3;
            this.EnvironmentUrlLabel.Text = "環境URL";
            // 
            // LoginUserNameLabel
            // 
            this.LoginUserNameLabel.AutoSize = true;
            this.LoginUserNameLabel.Location = new System.Drawing.Point(34, 84);
            this.LoginUserNameLabel.Name = "LoginUserNameLabel";
            this.LoginUserNameLabel.Size = new System.Drawing.Size(57, 12);
            this.LoginUserNameLabel.TabIndex = 3;
            this.LoginUserNameLabel.Text = "ユーザー名";
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Location = new System.Drawing.Point(36, 126);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(52, 12);
            this.LoginPasswordLabel.TabIndex = 3;
            this.LoginPasswordLabel.Text = "パスワード";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 226);
            this.Controls.Add(this.LoginPasswordLabel);
            this.Controls.Add(this.LoginUserNameLabel);
            this.Controls.Add(this.EnvironmentUrlLabel);
            this.Controls.Add(this.LoginPassword);
            this.Controls.Add(this.EnvironmentUrl);
            this.Controls.Add(this.LoginUserName);
            this.Controls.Add(this.Login);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox LoginUserName;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.TextBox EnvironmentUrl;
        private System.Windows.Forms.Label EnvironmentUrlLabel;
        private System.Windows.Forms.Label LoginUserNameLabel;
        private System.Windows.Forms.Label LoginPasswordLabel;
    }
}

