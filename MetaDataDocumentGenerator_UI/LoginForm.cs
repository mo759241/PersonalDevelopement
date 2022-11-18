using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace MetaDataDocumentGenerator_UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                // 指定したD365環境の認証を通してソリューション一覧画面を起動
                Helper.setOrgService(EnvironmentUrl.Text, LoginUserName.Text, LoginPassword.Text);
                this.Visible = false;
                new SelectSolutionForm().Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
