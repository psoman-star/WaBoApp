using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace What.Api
{
    public class ApiBase
    {

        public IWebDriver Driver { get; set; }

        private ChromeDriverService _driverService;
        private ChromeOptions _options;
        public ApiBase()
        {
            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;
            _options = new ChromeOptions();
            //Hide Chrome is being controlled by automated software"
            _options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            _options.AddExcludedArgument("enable-automation");
            _options.AddArguments("--lang=en");
            _options.AddArgument("start-maximized");
            _options.AddArgument("--ignore-certificate-errors");
            // var path = Assembly.GetExecutingAssembly().Location;
            // var directory = Path.GetDirectoryName(path) + "\\Cache";
            //  _options.AddArgument($"user-data-dir={directory}");
            _options.AddAdditionalOption("useAutomationExtension", false);
            _options.AddArguments("--disable-notifications");
            _options.AddArguments("disable-infobars");
            _options.AddArguments("--disable-blink-features=AutomationControlled");
        }

        public bool IsStart { get; set; }
        public void Start(string url)
        {
            if (this.Driver == null)
            {
                this.Driver = new ChromeDriver(_driverService, _options);

            }
            this.Driver.Navigate().GoToUrl(url);
            this.IsStart = true;


        }

        public void GoUrl(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            if (this.Driver != null)
            {
                this.Driver.Quit();
            }
        }

        public void Close()
        {
            if (this.Driver != null)
            {
                this.Driver.Close();
            }

        }
    }
}
