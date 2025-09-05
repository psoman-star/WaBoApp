using Krypton.Toolkit;
using System.Diagnostics;
using What.Api;
using WaApp.Models;
using WaApp.Utils;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WaApp.CustomControl
{
    public partial class PhoneCheckControl : UserControl
    {
        private string fileName = "Delay.txt";
        public WhatsAppApi AppApi { get; set; }
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private int delayMin = 5;
        private int delayMax = 10;
        public override string Text => "Verify";
        public PhoneCheckControl()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var list = ImportUtil.ImportPhone().Select(s => new PhoneCheck { PhoneNumber = s.TrimStart('+') }).ToList();
            this.dgvPhone.DataSource = list;
            if (list != null)
            {
                this.labTotal.Text = list.Count.ToString();
            }

        }



        private async void btnStart_Click(object sender, EventArgs e)
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
            this.AppApi.Refresh();
            var phoneList = this.dgvPhone.DataSource as List<PhoneCheck>;

            var list = FileUtils.GetAll<DelaySetting>(fileName);
            if (list.Count > 0)
            {
                var model = list.FirstOrDefault();
                delayMin = model.DelayMin;
                delayMax = model.DelayMax;
            }

            var interval = GetRandom(delayMin, delayMax);

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnExport.Enabled = false;
            var token = this._cancellationTokenSource.Token;
            await Task.Factory.StartNew(() =>
            {
                this.SendToUserList(phoneList, interval, token);
            }, token).ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                    this.btnExport.Enabled = true;
                }));
                this._cancellationTokenSource = new CancellationTokenSource();
            });
        }

        private void SendToUserList(List<PhoneCheck> phoneList, int delay, CancellationToken token = default)
        {

            var nums = 0;
            foreach (var user in phoneList)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                nums++;
                var rModel = new SendResult();
                rModel.Phone = user.PhoneNumber;
                var result = Tuple.Create(false, "");
                try
                {
                    result = this.AppApi.VerifyPhone(user.PhoneNumber);
                    rModel.Reason = result.Item2;
                }
                catch (Exception ex)
                {
                    rModel.Reason = ex.Message;
                }
                rModel.IsSuccess = result.Item1;
                this.AddRow(rModel);
                SpinWait.SpinUntil(() => false, delay * 1000);
            }


        }



        private int GetRandom(int min, int max)
        {
            return new Random().Next(min, max);
        }
        private void AddRow(SendResult item)
        {
            if (this.InvokeRequired)
            {
                var img = item.IsSuccess ? this.imageList1.Images[0] : this.imageList1.Images[1];
                this.Invoke(new Action(() =>
                {
                    if (item.IsSuccess)
                    {
                        var successNum = Convert.ToInt32(this.labSuccess.Text);
                        this.labSuccess.Text = (++successNum).ToString();
                    }
                    else
                    {
                        var failNum = Convert.ToInt32(this.labFail.Text);
                        this.labFail.Text = (++failNum).ToString();
                    }
                    this.dgvResult.Rows.Insert(0, new object[] { item.Phone, item.IsSuccess, img, item.Reason });
                }));
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dgvResult.Rows.Count == 0)
            {
                KryptonMessageBox.Show("No Data!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                return;
            }

            var list = new List<string>();
            foreach (DataGridViewRow row in this.dgvResult.Rows)
            {
                var isSuccess = Convert.ToBoolean(row.Cells["Column3"].Value);
                if (isSuccess)
                {
                    var phone = row.Cells["Column2"].Value.ToString();
                    list.Add(phone);
                }
            }
            ImportUtil.ExportFile(list);
        }
    }
}
