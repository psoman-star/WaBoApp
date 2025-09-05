using Krypton.Navigator;
using Krypton.Toolkit;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaApp.CustomControl;
using WaApp.Utils;
using What.Api;

namespace WaApp
{
    public partial class FrmMain : KryptonForm
    {
        private WhatsAppApi appApi = new WhatsAppApi();
        public FrmMain()
        {
            InitializeComponent();
            this.Width = FormUtils.GetAutoWidth(1359);
            this.Height = FormUtils.GetAutoHeight(1359, 1057);
        }
        private void CreatePage(Control control)
        {
            var page = new KryptonPage
            {
                Text = control.Text,
                TextTitle = control.Text
            };
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);

            var bsa = new ButtonSpecAny
            {
                Tag = page,
                Style = PaletteButtonStyle.FormClose,
                Type = PaletteButtonSpecStyle.Close,
            };
            bsa.Click += new EventHandler(OnClosePage);
            page.ButtonSpecs.Add(bsa);

            var cell = this.kryptonNavigator1;
            if (cell.Pages.All(p => p.Text != page.Text))
            {
                cell.Pages.Add(page);
                cell.SelectedPage = page;
            }
            else
            {
                var page1 = cell.Pages.FirstOrDefault(p => p.Text == page.Text);
                cell.SelectedPage = page1;

            }

        }

        private void OnClosePage(object sender, EventArgs e)
        {
            var bsa = (ButtonSpecAny)sender;
            var page = (KryptonPage)bsa.Tag;
            if (page != null)
            {
                this.kryptonNavigator1.Pages.Remove(page);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.Invoke(new Action(() =>
                {
                    new FrmUpdate().ShowDialog();
                    appApi.Start();
                }));
            });

        }

        private void krgbBtnMessage_Click(object sender, EventArgs e)
        {
            CreatePage(new MsgControl());
        }

        private void krgbImport_Click(object sender, EventArgs e)
        {
            var phoneFrm = new PhoneSendControl
            {
                AppApi = this.appApi
            };
            CreatePage(phoneFrm);
        }

        private void krgbBtnSet_Click(object sender, EventArgs e)
        {
            new FrmConfig().ShowDialog();
        }

        private void krgbImportContact_Click(object sender, EventArgs e)
        {
            var cFrm = new ContactSendControl
            {
                AppApi = this.appApi
            };
            CreatePage(cFrm);

        }

        private void krgbSendMsg_Click(object sender, EventArgs e)
        {
            var cFrm = new ScrapeContactControl
            {
                AppApi = this.appApi
            };
            CreatePage(cFrm);

        }

        private void krgbGroupMsg_Click(object sender, EventArgs e)
        {
            var cFrm = new ScrapeGroupControl
            {
                AppApi = this.appApi
            };
            CreatePage(cFrm);

        }

        private void krgbScrapeMember_Click(object sender, EventArgs e)
        {
            var cFrm = new ScrapeGroupMemberControl
            {
                AppApi = this.appApi
            };
            CreatePage(cFrm);
        }

        private void kryptonRibbonGroupButton6_Click(object sender, EventArgs e)
        {

        }

        private void krBtnCheck_Click(object sender, EventArgs e)
        {
            var cFrm = new PhoneCheckControl
            {
                AppApi = this.appApi
            };
            CreatePage(cFrm);
        }

        private void kryptonRibbonGroupGallery1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var index = this.kryptonRibbonGroupGallery1.SelectedIndex;
            //if (index <= -1) return;
            //string lang;
            //switch (index)
            //{
            //    case 0:
            //    case 5:
            //        lang = "en";
            //        break;
            //    case 1:
            //        lang = "ar";
            //        break;
            //    case 2:
            //        lang = "zh-CN";
            //        break;
            //    case 3:
            //        lang = "es";
            //        break;
            //    case 4:
            //        lang = "nl-BE";
            //        break;
            //    case 6:
            //        lang = "de-DE";
            //        break;
            //    case 7:
            //        lang = "nb-NO";
            //        break;
            //    case 11:
            //        lang = "vi";
            //        break;
            //    case 12:
            //        lang = "ru";
            //        break;
            //    case 13:
            //        lang = "zh-HK";
            //        break;
            //    case 14:
            //        lang = "it";
            //        break;
            //    case 15:
            //        lang = "km-KH";
            //        break;
            //    default:
            //        lang = "en";
            //        break;
            //}
            //ChangeLang(lang);
        }

        private void ChangeLang(string lang = "en")
        {
            LanguageUtils.ChangeLanguage(lang);
            this.rbTabSet.Text = LanguageUtils.GetName(nameof(rbTabSet));
            this.rbTabContact.Text = LanguageUtils.GetName(nameof(rbTabContact));
            this.rbTabGroups.Text = LanguageUtils.GetName(nameof(rbTabGroups));
            this.rbTabAutoBot.Text = LanguageUtils.GetName(nameof(rbTabAutoBot));
            this.rbTabAbout.Text = LanguageUtils.GetName(nameof(rbTabAbout));

            this.krgbBtnSet.TextLine1 = LanguageUtils.GetName(nameof(krgbBtnSet));
            this.krgbBtnMessage.TextLine1 = LanguageUtils.GetName(nameof(krgbBtnMessage));
            this.krgbImport.TextLine1 = LanguageUtils.GetName(nameof(krgbImport));
            this.krgbImportContact.TextLine1 = LanguageUtils.GetName(nameof(krgbImportContact));
            this.krgbSendMsg.TextLine1 = LanguageUtils.GetName(nameof(krgbSendMsg));
            this.krBtnCheck.TextLine1 = LanguageUtils.GetName(nameof(krBtnCheck));

            this.krgbGroupMsg.TextLine1 = LanguageUtils.GetName(nameof(krgbGroupMsg));
            this.krgbScrapeMember.TextLine1 = LanguageUtils.GetName(nameof(krgbScrapeMember));
            this.krgbBotMessage.TextLine1 = LanguageUtils.GetName(nameof(krgbBotMessage));
            this.krgbBot.TextLine1 = LanguageUtils.GetName(nameof(krgbBot));
            this.krgbAbout.TextLine1 = LanguageUtils.GetName(nameof(krgbAbout));
            this.krgbHelp.TextLine1 = LanguageUtils.GetName(nameof(krgbHelp));
            this.krgbConactUs.TextLine1 = LanguageUtils.GetName(nameof(krgbConactUs));

            this.Text = LanguageUtils.GetName("FrmMain");

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (KryptonMessageBox.Show("Are you sure exit?", "Info",
                                    MessageBoxButtons.YesNo, KryptonMessageBoxIcon.QUESTION, showCtrlCopy: false)
                             == DialogResult.Yes)
                {
                    this.appApi.Quit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void krgbConactUs_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/captainC999");
        }

        private void krgbAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void krgbBot_Click(object sender, EventArgs e)
        {

        }

        private void krgbHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
