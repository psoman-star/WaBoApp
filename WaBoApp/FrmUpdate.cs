using Krypton.Toolkit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaApp.Utils;

namespace WaApp
{
    public partial class FrmUpdate : KryptonForm
    {
        private ChromeDriverUpdate chromeDrive = new ChromeDriverUpdate();
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private async void FrmUpdate_Load(object sender, EventArgs e)
        {
            await chromeDrive.CheckUpate(s => this.Progess(s))
                .ContinueWith(async t =>
                {
                    var result = t.Result;
                    this.InvokeOnUiThreadIfRequired(() => this.labInfo.Text = result.Message);
                    await Task.Delay(2000);
                    this.DialogResult = DialogResult.OK;
                });
        }

        private void Progess(int p)
        {
            this.InvokeOnUiThreadIfRequired(() => this.progressBar1.Value = p);
        }
    }
}
