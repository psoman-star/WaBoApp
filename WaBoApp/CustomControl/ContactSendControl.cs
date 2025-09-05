using Krypton.Toolkit;
using What.Api;
using WaApp.Models;
using WaApp.Utils;
using System.Windows.Forms;
using System.Threading;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace WaApp.CustomControl
{
    public partial class ContactSendControl : UserControl
    {
        private string fileName = "Delay.txt";
        public WhatsAppApi AppApi { get; set; }
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private int msgMin = 5;
        private int msgMax = 15;
        private int delayMin = 5;
        private int delayMax = 10;
        private int msgNums = 10;

        public override string Text => "Import Contact";
        public ContactSendControl()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "Text File|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var list = File.ReadAllLines(open.FileName).Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => new ContactModel { Name = s }).ToList();
                this.dgvPhone.DataSource = list;
                if (list != null)
                {
                    this.labTotal.Text = list.Count.ToString();
                }
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.AppApi.IsLogin())
            {
                KryptonMessageBox.Show("Please login first!", "Info",
                           MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }
            if (this.dgvPhone.Rows.Count == 0)
            {
                KryptonMessageBox.Show("No Data!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }
            var phoneList = this.dgvPhone.DataSource as List<ContactModel>;
            var msgList = FileUtils.GetAll<MessageModel>().Where(m => m.Type == MessageType.Contact).ToList();
            if (msgList.Count == 0)
            {
                KryptonMessageBox.Show("Please add  ImportType Message!", "Info",
                         MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
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

        private void SendToUserList(List<ContactModel> phoneList, List<MessageModel> msgList,
            int msgNumDelay, int delay, int msgNum, CancellationToken token = default)
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
                rModel.Phone = user.Name;
                var result = Tuple.Create(false,"");
                var msgModel = this.GetRandomMsg(msgList);
                try
                {
                    if (string.IsNullOrEmpty(msgModel.Content))
                    {
                        rModel.Reason = "Please set the message content!";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(msgModel.Content))
                        {
                            var msg = string.Format(msgModel.Content, user.Name);
                            result = this.AppApi.SearchSendMsg(user.Name, msg);
                        }
                        if (msgModel.IsAttachment && !string.IsNullOrEmpty(msgModel.Attachment))
                        {
                            var fileList = msgModel.Attachment.Split(Environment.NewLine.ToCharArray())
                                .Where(s => !string.IsNullOrEmpty(s.Trim())).ToList();
                            foreach (var item in fileList)
                            {
                                if (Path.HasExtension(item))
                                {
                                    this.AppApi.SearchSendFile(user.Name, item);
                                }
                            }

                        }
                        rModel.Reason = result.Item2;

                    }

                }
                catch (Exception ex)
                {
                    rModel.Reason = "Page open timed out!";
                }
                rModel.IsSuccess = result.Item1;
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
                        this.labSuccess.Text = successNum++.ToString();
                    }
                    else
                    {
                        var failNum = Convert.ToInt32(this.labFail.Text);
                        this.labFail.Text = failNum++.ToString();
                    }
                    this.dgvResult.Rows.Insert(0, new object[] { item.Phone, img, item.Reason });
                }));
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();
        }
    }
}
