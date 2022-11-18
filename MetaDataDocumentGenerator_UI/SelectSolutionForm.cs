using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using MetaDataDocumentGenerator_UI;

namespace MetaDataDocumentGenerator_UI
{
    public partial class SelectSolutionForm : Form
    {
        public SelectSolutionForm()
        {
            InitializeComponent();

            using (var context = new MyContext(Helper.orgSvc))
            {
                // 環境のソリューション一覧を取得
                var solQuery = from sol in context.SolutionSet
                               where sol.IsApiManaged == false && sol.IsVisible == true
                               select sol;

                var solutions = solQuery.ToList();

                foreach (var solution in solutions)
                {
                    SolutionList.Items.Add(solution.FriendlyName).SubItems.Add(solution.UniqueName);
                }
            }
        }

        private void SelectSolutionOk_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new GenerateDocumentForm(SolutionList.SelectedItems[0].SubItems[1].Text).Show();
        }
    }
}
