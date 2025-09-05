using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WaApp.Models;
using WaApp.Utils;

namespace WaApp.CustomControl
{
    public partial class MsgControl : UserControl
    {
        public MsgControl()
        {
            InitializeComponent();
        }

        public override string Text => "Message";
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmMsgAdd();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Bind();
            }
        }

        private void Bind()
        {
            var list = FileUtils.GetAll<MessageModel>();
            this.dgvList.DataSource = list;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.Rows.Count == 0)
            {
                KryptonMessageBox.Show("NO Data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
            {
                KryptonMessageBox.Show("Please select Row!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            if (KryptonMessageBox.Show("Are you sure del?", "Info", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, showCtrlCopy: false) == DialogResult.Yes)
            {
                var index = this.dgvList.CurrentRow.Index;
                var list = this.dgvList.DataSource as List<MessageModel>;
                list.RemoveAt(index);
                var nlist = list.ToList();
                FileUtils.Save(nlist);
                this.Bind();
                KryptonMessageBox.Show("Del Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
            }
        }

        private void MsgControl_Load(object sender, EventArgs e)
        {
            this.Bind();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvList.RowCount == 0)
            {
                KryptonMessageBox.Show("NO Data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
            {
                KryptonMessageBox.Show("Please select Row!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, showCtrlCopy: false);
                return;
            }
            var frm = new FrmMsgAdd
            {
                IsAdd = false
            };
            var model = this.dgvList.CurrentRow.DataBoundItem as MessageModel;
            frm.MessageModel = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Bind();
            }

        }


    }
}
