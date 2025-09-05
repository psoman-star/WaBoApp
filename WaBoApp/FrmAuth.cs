
using Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace WaApp
{
    public partial class FrmAuth : KryptonForm
    {
        public string Msg { get; set; }
        public FrmAuth()
        {
            InitializeComponent();
        }

        private  async void btnAuth_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtPurchaseCode.Text))
            {
                KryptonMessageBox.Show("Please enter your purchase code!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, showCtrlCopy: false);
                return;
            }
            else
            {
                
                

            }
        }

        private void FrmAuth_Load(object sender, EventArgs e)
        {
            this.labMsg.Text = this.Msg;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmAuth_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
