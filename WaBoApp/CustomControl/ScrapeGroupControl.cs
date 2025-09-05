using Krypton.Toolkit;
using What.Api;
using WaApp.Models;
using WaApp.Utils;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WaApp.CustomControl
{
    public partial class ScrapeGroupControl : UserControl
    {
        private string fileName = "Delay.txt";
        private int phoneNum = 0;
        public WhatsAppApi AppApi { get; set; }
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private int msgMin = 5;
        private int msgMax = 15;
        private int delayMin = 5;
        private int delayMax = 10;
        private int msgNums = 10;
        public override string Text => "Scrape Groups";
        public ScrapeGroupControl()
        {
            InitializeComponent();
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

            var phoneList = GetPhoneList();
            var msgList = FileUtils.GetAll<MessageModel>().Where(m => m.Type == MessageType.Group).ToList();
            if (msgList.Count == 0)
            {
                KryptonMessageBox.Show("Please add Message!", "Info",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                return;
            }
            var list = FileUtils.GetAll<DelaySetting>(fileName);
            if (list.Count > 0)
            {
                var model = list.FirstOrDefault();
                msgMax = model.MsgSendMax;
                msgMin = model.MsgSendMin;
                msgNums = model.MsgNums;
                delayMin = model.MsgDelayMin;
                delayMax = model.MsgDelayMax;
            }

            var msgNumInteval = GetRandom(msgMin, msgMax);
            var interval = GetRandom(delayMin, delayMax);

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            var token = this._cancellationTokenSource.Token;
            await Task.Factory.StartNew(() =>
            {
                this.SendToUserList(phoneList, msgList, msgNumInteval, interval, msgNums, token);
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


        private List<string> GetPhoneList()
        {
            var list = new List<string>();
            foreach (DataGridViewRow item in this.dgvPhone.Rows)
            {
                var phone = item.Cells[0]?.Value.ToString() ?? string.Empty;
                list.Add(phone);
            }
            return list;
        }
        private void SendToUserList(List<string> gList, List<MessageModel> msgList,
            int msgNumDelay, int delay, int msgNum, CancellationToken token = default)
        {

            var nums = 0;
            foreach (var group in gList)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                nums++;
                var rModel = new SendResult();
                rModel.Phone = group;
                var msgModel = this.GetRandomMsg(msgList);
                try
                {
                    var result = this.AppApi.SendMsgToGroup(group, msgModel.Content);
                    if (result.Item1)
                    {
                        if (msgModel.IsAttachment && !string.IsNullOrEmpty(msgModel.Attachment))
                        {
                            if (Path.HasExtension(msgModel.Attachment))
                            {
                                this.AppApi.SearchSendFile(group, msgModel.Attachment);
                            }
                        }
                    }
                    rModel.IsSuccess = result.Item1;
                    rModel.Reason = result.Item2;
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    rModel.Reason = ex.Message;
                }
                this.AddRow(rModel);
                SpinWait.SpinUntil(() => false, delay * 1000);
                if (nums % msgNum == 0)
                {
                    SpinWait.SpinUntil(() => false, msgNumDelay * 1000);
                }
            }


        }

        private MessageModel GetRandomMsg(List<MessageModel> msgList)
        {
            var index = new Random().Next(msgList.Count);
            return msgList[index];
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
                        ++successNum;
                        this.labSuccess.Text = successNum.ToString();
                    }
                    else
                    {
                        var failNum = Convert.ToInt32(this.labFail.Text);
                        ++failNum;
                        this.labFail.Text = failNum.ToString();
                    }
                    this.dgvResult.Rows.Insert(0, new object[] { item.Phone, img, item.Reason });
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
                           MessageBoxButtons.OK, MessageBoxIcon.Warning, showCtrlCopy: false);
                return;
            }
            this.phoneNum = 0;
            this.btnContact.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = false;
            Action<string> action = s =>
            {
                //RegexUtil.CheckPhone(s)
                phoneNum++;
                this.Invoke(new Action(() =>
                {
                    this.dgvPhone.Rows.Insert(0, new object[] { s });
                    this.labTotal.Text = phoneNum.ToString();

                }));

            };
            Task.Factory.StartNew(() =>
            {
                this.AppApi.GetContactList(action,true);
            }).ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    this.btnContact.Enabled = true;
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = true;
                }));

            });
        }
    }
}
