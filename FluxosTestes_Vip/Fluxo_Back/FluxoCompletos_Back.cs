using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluxosTestes_Vip.Fluxo_Site.Controller;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Threading;
using FluxosTestes_Vip.Controller;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium;
using Handlenium;


namespace FluxosTestes_Vip.Fluxo_Back
{
    [TestClass]
    public class FluxoCompletos_Back
    {
        PaginaBase PaginaBase = new PaginaBase();
        QueryDAO QueryDAO = new QueryDAO();
        WritetextFile WritetextFile = new WritetextFile();
        private string _screenshotErro = ConfigurationManager.AppSettings["screenshotsPath"];
        private string driverPath = ConfigurationManager.AppSettings["chromedriverPath"];
        ChromeDriver _chrome;
        ChromeDriver _chrome2;

        #region Contrutor 
        public FluxoCompletos_Back()
        {
            _chrome = new ChromeDriver();
            _chrome2 = new ChromeDriver();
        }
        #endregion
        #region atributos
        public string Login = "admin";
        public string Senha = "123456";
        public string codigo = "1111";
        public string Dtaleilao = "23/Novembro/2017 18:45";
        public string DtaFimleilao = "27/Novembro/2017 20:45";
        #endregion

        #region Métodos Testes

        #region Login 
        [TestMethod]
        public void LoginBack()
        {
            try
            {
                PaginaBase.NavegaBack(_chrome);
                Thread.Sleep(1000);
                AjustSendKeys.SendKeysById("Login", Login, _chrome);
                AjustSendKeys.SendKeysById("Senha",Senha, _chrome);
                AjustClick.ClickByXPath("/html/body/div/div/div[1]/div[1]/form/div[2]/div[2]/button", _chrome);
                Thread.Sleep(200);
                WritetextFile.SalvaTxt("Login Realizado Com sucesso");
            }
            catch
            {
                WritetextFile.SalvaTxt("Erro: Erro ao tentar realizar Login. Tela do erro na pasta Falhas");
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "//LoginBack.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion
 
        #region Consulta leilões
        [TestMethod]
        public void ConsultaLeiloes()
        {
            try
            {
                LoginBack();


            }
            catch(Exception e)
            {

            }
        }

        #endregion

        #region Criar leilão  Fluxo principal
        [TestMethod]
        public void CriarLeilao()
        {
            try
            { 
                LoginBack();
                IList<IWebElement> Menu = _chrome.FindElementsByCssSelector("body > div > div:nth-child(1) > div > div > div.page-header-menu > div > div > ul > li:nth-child(1) > ul > li");
                foreach (var ele in Menu)
                {
                    if (ele.Text.Equals("Criar"))
                    {
                        ele.Click();
                    }
                }
                
                AjustSendKeys.SendKeysByXPath("//*[@id=\"form_control_1\"]", codigo, _chrome);
                IList<IWebElement> ambiente = _chrome.FindElementsByCssSelector("#TipoLeilao > option");
                foreach(var ele in ambiente)
                {
                    if (ele.Text.Equals("Presencial"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                IList<IWebElement> leiloeiro = _chrome.FindElementsByCssSelector("#LeiloeiroId > option");
                foreach(var ele in leiloeiro)
                {
                    if (ele.Text.Equals("Teste"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                IList<IWebElement> Local = _chrome.FindElementsByCssSelector("#EnderecoId > option:nth-child(2)");
                foreach(var ele in Local)
                {
                    if (ele.Text.Equals("Loja Centro"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                AjustSendKeys.SendKeysById("DataInicio", Dtaleilao, _chrome);
                // AjustSendKeys.SendKeysById("", DtaFimleilao, _chrome);
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div:nth-child(3) > div > input[type=\"file\"]").Click();
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-12.MarginGeral > div > button").Click();
                WritetextFile.SalvaTxt("Leilão criado com Sucesso");
                
                //Criar Leioloeiro
                //_chrome.FindElementByCssSelector("#form-control > div > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > a").Click();



            }
            catch (Exception e)
            {
                WritetextFile.SalvaTxt("Erro: Erro ao tentar criar leilão. Tela do erro na pasta Falhas");
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "CriarLeilao.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg); 
            }
        }
        #endregion

        #region Criar leilão Fluxo alternativo
        [TestMethod]
        public void Criarleilao_alt()
        {
            try
            {
                LoginBack();
                IList<IWebElement> Menu = _chrome.FindElementsByCssSelector("body > div > div:nth-child(1) > div > div > div.page-header-menu > div > div > ul > li:nth-child(1) > ul > li");
                foreach (var ele in Menu)
                {
                    if (ele.Text.Equals("Criar"))
                    {
                        ele.Click();
                    }
                }

                AjustSendKeys.SendKeysByXPath("//*[@id=\"form_control_1\"]", codigo, _chrome);
                IList<IWebElement> ambiente = _chrome.FindElementsByCssSelector("#TipoLeilao > option");
                foreach (var ele in ambiente)
                {
                    if (ele.Text.Equals("Online"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                IList<IWebElement> leiloeiro = _chrome.FindElementsByCssSelector("#LeiloeiroId > option");
                foreach (var ele in leiloeiro)
                {
                    if (ele.Text.Equals("Leilao"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                IList<IWebElement> Local = _chrome.FindElementsByCssSelector("#EnderecoId > option:nth-child(2)");
                foreach (var ele in Local)
                {
                    if (ele.Text.Equals("Loja Centro"))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-6 > div:nth-child(3) > div > input").SendKeys(Dtaleilao);
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-6 > div:nth-child(4) > div > input").SendKeys(DtaFimleilao);
                // AjustSendKeys.SendKeysById("", DtaFimleilao, _chrome);
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div:nth-child(3) > div > input[type=\"file\"]").Click();
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-12.MarginGeral > div > button").Click();
                WritetextFile.SalvaTxt("Leilão criado com Sucesso");

            }
            catch (Exception e)
            {
                WritetextFile.SalvaTxt("Erro: Erro ao tentar criar leilão. Tela do erro na pasta Falhas");
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "Criarleilao_alt.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

            }
        }
        #endregion

        #region Testes Rodapé
        [TestMethod]
        public void Rodapé_Back()
        {
            try
            {
                LoginBack();

            }
            catch(Exception e)
            {
                WritetextFile.SalvaTxt("Erro: Erro ao tentar Acessar links de Rodapé. Tela do erro na pasta Falhas");
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "//Rodapé_Back.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

            }
        }

        #endregion



        #endregion



    }
}
