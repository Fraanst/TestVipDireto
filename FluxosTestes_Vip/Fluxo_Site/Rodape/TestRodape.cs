using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FluxosTestes_Vip.Fluxo_Site.Controller;

namespace FluxosTestes_Vip.Fluxo_Site.Rodape
{
    [TestClass]
    public class TestRodape : PaginaBase
    {
        PaginaBase paginabase = new PaginaBase();

        ChromeDriver _Chrome;
        private string _screenshotErro = ConfigurationManager.AppSettings["screenshotsPath"];
        private string driverPath = ConfigurationManager.AppSettings["chromedriverPath"];

        #region Construtor
        public TestRodape()
        {
            _Chrome = new ChromeDriver();
        }
        #endregion

        [TestMethod]
        #region Links Instituicionais
        public void Institucionais()
        {
            try
            {
                NavegaDev(_Chrome);
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                var s = _Chrome.GetScreenshot();
                s.SaveAsFile(ConfigurationManager.AppSettings["_screenshotErro"] + "\\Instituicionais.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }

        #endregion

    }
}
