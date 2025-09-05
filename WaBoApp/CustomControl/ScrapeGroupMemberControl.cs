using Krypton.Toolkit;
using What.Api;
using WaApp.Utils;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace WaApp.CustomControl
{
    public partial class ScrapeGroupMemberControl : UserControl
    {
        public WhatsAppApi AppApi { get; set; }
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public override string Text => "GroupMember";
        public ScrapeGroupMemberControl()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (this.btnStart.Text == "Start")
            {
                if (!this.AppApi.IsLogin())
                {
                    KryptonMessageBox.Show("Please login first!", "Info",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                    return;
                }
                if (this.dgvPhone.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("No Data!", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                    return;
                }
                this.btnStart.Text = "Stop";
                var groupName = this.dgvPhone.CurrentRow.Cells[0].Value.ToString();
                Action<string> action = (s) => this.Invoke(new Action(() =>
                {
                    if (RegexUtil.CheckPhone(s))
                    {
                        string[] row = { (this.listView1.Items.Count + 1).ToString(), s };
                        var item = new ListViewItem(row);
                        this.listView1.Items.Add(item);
                        var index = this.listView1.Items.Count - 1;
                        this.listView1.Items[index].EnsureVisible();
                    }
                }));

                this.listView1.Items.Clear();
                this.btnExport.Enabled = true;
                var token = this._cancellationTokenSource.Token;
                await Task.Factory.StartNew(() =>
                {
                    this.AppApi.GetGroupList(groupName, action, token);
                }, token).ContinueWith(t =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.btnStart.Enabled = true;
                        this.btnExport.Enabled = true;
                        this.btnStart.Text = "Start";
                    }));
                    this._cancellationTokenSource = new CancellationTokenSource();
                });

            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.btnStart.Enabled = false;
                }));
                this._cancellationTokenSource.Cancel();
            }

        }




        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count == 0)
            {
                KryptonMessageBox.Show("No Data!", "Info",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                return;
            }
            var list = this.listView1.Items.Cast<ListViewItem>().Select(item => item.SubItems[1].Text).ToList();
            ImportUtil.ExportFile(list);
            KryptonMessageBox.Show("Export Finish!", "Info",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (!this.AppApi.IsLogin())
            {
                KryptonMessageBox.Show("Please login first!", "Info",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                return;
            }
            this.btnContact.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnExport.Enabled = false;
            Action<string> action = s =>
            {
                this.Invoke(new Action(() =>
                {
                    this.dgvPhone.Rows.Insert(0, new object[] { s });

                }));

            };
            var token = this._cancellationTokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                this.AppApi.GetContactList(action, true, token);
            },token).ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    this.btnContact.Enabled = true;
                    this.btnStart.Enabled = true;
                    this.btnExport.Enabled = true;
                }));

            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();
        }
    }
}
