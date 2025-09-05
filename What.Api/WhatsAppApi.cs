using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml.Linq;

namespace What.Api
{
    public class WhatsAppApi : ApiBase
    {
        private string whatsUrl = "https://web.whatsapp.com/";

        public bool IsLogin()
        {
            return true;
        }


        public void Start()
        {
            base.Start(this.whatsUrl);
        }
        public Tuple<bool, string> VerifyPhone(string phone)
        {
            var url = $"{this.whatsUrl}send?phone={phone}";
            this.GoUrl(url);
            SpinWait.SpinUntil(() => false, 5000);
            return this.CheckPhoneIsExist();
        }
        private Tuple<bool, string> CheckPhoneIsExist()
        {
            return new Tuple<bool, string>(false,string.Empty);
        }

        private Tuple<bool, string> Repeated()
        {
            var result = Tuple.Create(false, "");
           
            return result;

        }


        public Tuple<bool, string> SendMsg(string phone, string text)
        {
            var content = HttpUtility.UrlEncode(text);
            var url = $"{this.whatsUrl}send?phone={phone}&text={content}";
            this.GoUrl(url);
            SpinWait.SpinUntil(() => false, 5000);
            var result = this.CheckPhoneIsExist();
          
            return result;
        }


        public bool SendFile(string phone, string filePath)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;
        }


        private int GetTotal()
        {
            return 0;
        }

        public List<string> GetContactList(Action<string> action, bool isGroup = false, CancellationToken cancellation = default)
        {
            this.Refresh(true);
            var list = new List<string>();
            var total = this.GetTotal();
            var prevLast = string.Empty;
            if (total == 0)
            {
                return list;
            }
           
            return list;
        }

        public void Refresh(bool isRefresh = false)
        {
            if (isRefresh)
            {
                this.Driver.Navigate().Refresh();
                SpinWait.SpinUntil(() => false, 5000);
              
            }

        }

        public Tuple<bool, string> SearchSendMsg(string phone, string text)
        {
            try
            {
              
                return Tuple.Create(true, "");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return Tuple.Create(false, ex.Message);
            }
        }

        public Tuple<bool, string> SendMsgToGroup(string groupName, string text)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return new Tuple<bool, string>(false, ex.Message);
            }
            return new Tuple<bool, string>(false, string.Empty);
        }

        public bool SearchSendFile(string phone, string filePath)
        {
            try
            {
                // this.Driver.SendKey(By.CssSelector(WhatsSelector.SearchInput), phone);
                SpinWait.SpinUntil(() => false, 200);
                this.Driver.FindElementWait(By.CssSelector("span[data-icon='clip']")).Click();
                SpinWait.SpinUntil(() => false, 100);
                this.Driver.FindElementWait(By.CssSelector("input[type='file']")).SendKeys(filePath);

                this.Driver.FindElementWait(By.CssSelector("span[data-icon='send']")).Click();
                SpinWait.SpinUntil(() => false, 1500);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return false;
            }

        }


     


        public void GetGroupList(string groupName, Action<string> action, CancellationToken token = default)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);

            }
        }

     


        public Tuple<bool, string, string> JoinGroup(string groupLink)
        {
            return new Tuple<bool, string, string>(false, string.Empty, string.Empty);
        }

       
        



     
    }
}
