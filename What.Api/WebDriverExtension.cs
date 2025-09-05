using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace What.Api
{
    public static class WebDriverExtension
    {

        public static IWebElement FindElementWait(this IWebDriver webDriver, By by, int timeOut = 5)
        {
            return null;

        }
        public static ReadOnlyCollection<IWebElement> FindElementsWait(this IWebDriver webDriver, By by, int timeOut = 5)
        {

            return null;
        }

        public static void MoveToElementCatch(this IWebDriver webDriver, IWebElement element)
        {
          

        }

        public static void MoveToElementAndClick(this IWebDriver webDriver, IWebElement element)
        {
           

        }


        public static void MoveToElementAndClick(this IWebDriver webDriver, By by)
        {
            

        }


        public static IWebElement FindElementCatch(this IWebDriver webDriver, By by)
        {

            return  null;
        }
        

        public static void SendKey(this IWebDriver webDriver, By bySearch, string keyword)
        {
           
        }

        

        public static void SendMsg(this IWebDriver webDriver, By bySearch, string message)
        {
           
        }


      
        public static IWebElement FindElementCatch(this IWebElement element, By by)
        {
            return null;
        }
    }


}
