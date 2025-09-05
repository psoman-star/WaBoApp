using Krypton.Toolkit;
using What.Api;
using WaApp.Models;
using WaApp.Utils;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WaApp.CustomControl
{
    public partial class JoinGroupControl : UserControl
    {
        private int phoneNum = 0;
        public WhatsAppApi AppApi { get; set; }
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public override string Text => "Join Group";
        public JoinGroupControl()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.AppApi.IsLogin())
            {
                KryptonMessageBox.Show("Please login first!", "Info",
                           MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }
            if (this.dgvGroup.Rows.Count == 0)
            {
                KryptonMessageBox.Show("No Data!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }

            var groupList = GetGroupList();
            var delayMin = 5;

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            var token = this._cancellationTokenSource.Token;
            await Task.Factory.StartNew(() =>
            {
                this.JoinGroup(groupList, delayMin, token);
            }, token).ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                }));
                this._cancellationTokenSource = new CancellationTokenSource();
            });
        }


        private List<string> GetGroupList()
        {
            var list = new List<string>();
            foreach (DataGridViewRow item in this.dgvGroup.Rows)
            {
                var group = item.Cells[0]?.Value.ToString() ?? string.Empty;
                list.Add(group);
            }
            return list;
        }
        private void JoinGroup(List<string> groupList, int delay, CancellationToken token = default)
        {

            foreach (var link in groupList)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                var rModel = new JoinResult();
                var result = this.AppApi.JoinGroup(link);
                rModel.Link = link;
                rModel.GroupName = result.Item2;
                rModel.IsSuccess = result.Item1;
                rModel.Reason = result.Item3;

                this.AddRow(rModel);
                SpinWait.SpinUntil(() => false, delay * 1000);
            }


        }


        private void AddRow(JoinResult item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.dgvResult.Rows.Insert(0, new object[] { item.GroupName, item.Link, item.IsSuccess, item.Reason });
                }));
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (!this.AppApi.IsLogin())
            {
                KryptonMessageBox.Show("Please login first!", "Info",
                           MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }
           
            var list = ImportUtil.ImportPhone();
            this.phoneNum = list.Count;
            this.labTotal.Text = this.phoneNum.ToString();
            foreach (var item in list)
            {
                this.dgvGroup.Rows.Insert(0, new object[] { item });
            }

        }
    }
}
