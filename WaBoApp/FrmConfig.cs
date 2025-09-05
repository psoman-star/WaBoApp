using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WaApp.Models;
using WaApp.Utils;

namespace WaApp
{
    public partial class FrmConfig : KryptonForm
    {
        private string fileName = "Delay.txt";
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            var list = FileUtils.GetAll<DelaySetting>(fileName);
            if (list.Count > 0)
            {
                var model = list.FirstOrDefault();
                this.delayMin.Value = model.DelayMin;
                this.delayMax.Value = model.DelayMax;
                this.nudSendDelayMin.Value = model.MsgDelayMin;
                this.nudSendDelayMax.Value = model.MsgDelayMax;
                this.nudSendMsgNum.Value = model.MsgNums;
                this.nudSendMsgMin.Value = model.MsgSendMin;
                this.nudSendMsgMax.Value = model.MsgSendMax;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var delayModel = new DelaySetting
            {
                DelayMin = (int)this.delayMin.Value,
                DelayMax = (int)this.delayMax.Value,
                MsgDelayMin = (int)this.nudSendDelayMin.Value,
                MsgDelayMax = (int)this.nudSendDelayMax.Value,
                MsgNums = (int)this.nudSendMsgNum.Value,
                MsgSendMin = (int)this.nudSendMsgMin.Value,
                MsgSendMax = (int)this.nudSendMsgMax.Value
            };
            var list = new List<DelaySetting>
            {
                delayModel
            };
            FileUtils.Save(list, fileName);
            KryptonMessageBox.Show("Set Success!", "Info",
                      MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
        }
    }
}
