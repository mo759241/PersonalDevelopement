using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;

namespace MetaDataDocumentGenerator_UI
{
    public static class Helper
    {
        public static CrmServiceClient Svc { get; set; }
        public static IOrganizationService orgSvc { get; set; }
        public static ProgressBar ProgresBar { get; set; }

        public static void setOrgService(string environmentUrl, string loginUserName, string loginPassword)
        {
            // Dynamicsへの接続
            var connectionString = @"AuthType=OAuth;Url=" + environmentUrl +
                @";Username=" + loginUserName +
                @";Password=" + loginPassword +
                @";ClientId=" + ConfigurationManager.AppSettings["CLIENT_ID"] +
                @";RedirectUri=" + ConfigurationManager.AppSettings["REDIRECT_URL"];
            Svc = new CrmServiceClient(connectionString);

            orgSvc = Svc.OrganizationWebProxyClient != null ?
                    (IOrganizationService)Svc.OrganizationWebProxyClient :
                    (IOrganizationService)Svc.OrganizationServiceProxy;
        }

        public static void StartProgressBar()
        {
            ProgresBar = new ProgressBar();
            ProgresBar.Show();

            var progressBar = ProgresBar.ProgressBar1;
            var percent = ProgresBar.ProgressPercentLabel;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            percent.Text = "0%";

            percent.Update();
        }

        public static void UpdateProgressBar(int progressPercent)
        {
            var progressBar = ProgresBar.ProgressBar1;
            var percent = ProgresBar.ProgressPercentLabel;
            progressBar.Value = progressPercent;
            percent.Text = progressPercent.ToString() + "%";
            percent.Update();
        }

        public static void CloseProgressBar()
        {
            ProgresBar.Close();
        }
    }
}
