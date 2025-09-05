using Krypton.Toolkit;
using System;
using System.Windows.Forms;
using WaApp.Models;
using WaApp.Utils;

namespace WaApp
{
    public partial class FrmMsgAdd : KryptonForm
    {
        public bool IsAdd { get; set; } = true;
        public MessageModel MessageModel { get; set; }
        public FrmMsgAdd()
        {
            InitializeComponent();

        }




        private void btnBrowser_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var file = open.FileName;
                this.txtAttacth.AppendText(file + Environment.NewLine);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTitle.Text))
            {
                KryptonMessageBox.Show("please enter title!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            if (string.IsNullOrEmpty(this.txtContent.Text))
            {
                KryptonMessageBox.Show("please enter content!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            var type = MessageType.Import;
            if (rbContact.Checked)
            {
                type = MessageType.Contact;
            }
            if (rbGroup.Checked)
            {
                type = MessageType.Group;
            }
            if (rbImport.Checked)
            {
                type = MessageType.Import;
            }
            var model = new MessageModel
            {
                Id = Guid.NewGuid().ToString("N"),
                Title = this.txtTitle.Text,
                Content = this.txtContent.Text,
                IsAttachment = this.cbAttachment.Checked,
                Attachment = this.txtAttacth.Text,
                IsDisable = this.cbDisable.Checked,
                Type = type,

            };
            if (this.IsAdd)
            {
                FileUtils.Save(model);
            }
            else
            {
                model.Id = MessageModel.Id;
                var list = FileUtils.GetAll<MessageModel>();
                var index = list.FindIndex(m => m.Id == MessageModel.Id);
                list[index] = model;
                FileUtils.Save(list);

            }

            KryptonMessageBox.Show("Save Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtAttacth.Clear();
        }

        private void FrmReplyAdd_Load(object sender, EventArgs e)
        {
            if (!IsAdd)
            {
                this.txtContent.Text = MessageModel.Content;
                this.txtTitle.Text = MessageModel.Title;
                this.cbAttachment.Checked = MessageModel.IsAttachment;
                this.txtAttacth.Text = MessageModel.Attachment;
                this.cbDisable.Checked = MessageModel.IsDisable;
                this.cbAttachment.Checked = MessageModel.IsAttachment;
                switch (MessageModel.Type)
                {
                    case MessageType.Import:
                        this.rbImport.Checked = true;
                        this.rbContact.Checked = false;
                        this.rbGroup.Checked = false;
                        break;
                    case MessageType.Contact:
                        this.rbImport.Checked = false;
                        this.rbContact.Checked = true;
                        this.rbGroup.Checked = false;
                        break;
                    case MessageType.Group:
                        this.rbImport.Checked = false;
                        this.rbContact.Checked = false;
                        this.rbGroup.Checked = true;
                        break;
                }
            }
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImport.Checked)
            {
                this.rbContact.Checked = false;
                this.rbGroup.Checked = false;
            }
        }

        private void rbContact_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContact.Checked)
            {
                this.rbImport.Checked = false;
                this.rbGroup.Checked = false;
            }
        }

        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGroup.Checked)
            {
                this.rbImport.Checked = false;
                this.rbImport.Checked = false;
            }
        }
    }
}
