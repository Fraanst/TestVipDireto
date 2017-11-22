using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluxosTestes_Vip.Fluxo_Site.Controller
{
   public class PaginaBase
    {
        private string driverPath = ConfigurationManager.AppSettings["chromedriverPath"];
        private string _screenshotErro = ConfigurationManager.AppSettings["screenshotsPath"];
        private string url_teste = ConfigurationManager.AppSettings["url_teste"];
        private string url_Hom = ConfigurationManager.AppSettings["url_Hom"];
        private string Url_Dev = ConfigurationManager.AppSettings["url_dev"];

        ChromeDriver _driver;


        #region Abre Chrome
        public void AbreChrome()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("test-type");
                options.AddArguments("start-maximized");
                options.AddArguments("--js-flags=--expose-gc");
                options.AddArguments("--enable-precise-memory-info");
                options.AddArguments("--disable-popup-blocking");
                options.AddArguments("--disable-default-apps");
                options.AddArguments("test-type=browser");
                options.AddArguments("disable-infobars");

                this._driver = new ChromeDriver(driverPath, options);
                this._driver.Manage().Window.Maximize();
                this._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            }
            catch (Exception e)
            {
                var s = _driver.GetScreenshot();
                s.SaveAsFile(ConfigurationManager.AppSettings["_screenshotErro"] + "\\AbreChrome.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion

        #region Navega Dev
        public void NavegaDev(ChromeDriver chromeDriver)
        {
            try
            {
                chromeDriver.Navigate().GoToUrl(Url_Dev);
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {

            }

        }
        #endregion

        #region Navega Teste
        public void NavegaTeste(ChromeDriver chromeDriver)
        {
            chromeDriver.Navigate().GoToUrl(url_teste);
            Thread.Sleep(1000);
        }
        #endregion

        #region Navega Hom
        public void NavegaHom(ChromeDriver chromeDriver)
        {
            chromeDriver.Navigate().GoToUrl(url_Hom);
            Thread.Sleep(1000);
        }
        #endregion

        #region Wait
        public WebDriverWait Wait(ChromeDriver chromeDriver)
        {
            try
            {
                return new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(120));
            }
            catch
            {
                throw;
            }
        }

        #endregion




    }
}
