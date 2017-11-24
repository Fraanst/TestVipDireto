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
        private string _screenshotErro = ConfigurationManager.AppSettings["_screenshotsPath"];
        private string driverPath = ConfigurationManager.AppSettings["chromedriverPath"];
        ChromeDriver _chrome;

        string success = string.Format("{0}", Environment.NewLine);
        string erro = string.Format("{0}", Environment.NewLine);


        #region Contrutor 
        public FluxoCompletos_Back()
        {
            _chrome = new ChromeDriver();

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
                AjustClick.ClickById("btnLogar", _chrome);
                Thread.Sleep(200);
                success += string.Format("Sucesso: Login Realizado Com sucesso{0}", Environment.NewLine);

            }
            catch
            {
                erro += string.Format("Erro: Erro ao tentar realizar Login. Tela do erro na pasta Falhas {0}", Environment.NewLine);
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
                AjustClick.ClickById("menuConsultarLeiloes", _chrome);
                if (_chrome.Url.Contains("Leilao/ListarLeiloes"))
                {
                    success += string.Format("Sucesso: Consulta de leilões realizada com sucesso {0}", Environment.NewLine);
                }

            }
            catch(Exception e)
            {
                erro += string.Format("Erro: Erro ao tentar Acessar Consulta de Leilões. Tela do erro na pasta Falhas {0}", Environment.NewLine);
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "//ConsultaLeiloes.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

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
                AjustClick.ClickById("menuLeiloes", _chrome);
                AjustClick.ClickById("menuCriarLeilao", _chrome);
                Thread.Sleep(1000);
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
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-6 > div:nth-child(1) > div > span > button").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(48) > div.datetimepicker-days > table > tbody > tr:nth-child(5) > td:nth-child(2)").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(48) > div.datetimepicker-hours > table > tbody > tr > td > span:nth-child(10)").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(48) > div.datetimepicker-minutes > table > tbody > tr > td > span:nth-child(7)").Click();
                Thread.Sleep(1000);
                //_chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div:nth-child(3) > div > input[type=\"file\"]").Click();
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-12.MarginGeral > div > button").Click();
                if (_chrome.Url.Contains("/Leilao/ListarLeiloes"))
                {
                    success += string.Format("Leilão criado com Sucesso {0}", Environment.NewLine);
                    _chrome.Close();
                }

                erro += string.Format("Erro: Não foi possivel criar leilão. Tela do erro na pasta Falhas {0}", Environment.NewLine);
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "CriarLeilao.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
                _chrome.Close();          

            }
            catch (Exception e)
            {
                erro += string.Format("Erro: Erro ao tentar criar leilão. Tela do erro na pasta Falhas {0}", Environment.NewLine);
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
                AjustClick.ClickById("menuLeiloes", _chrome);
                AjustClick.ClickById("menuCriarLeilao", _chrome);
                Thread.Sleep(1000);
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
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-6 > div:nth-child(3) > div > span > button").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(46) > div.datetimepicker-days > table > tbody > tr:nth-child(5) > td:nth-child(3)").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(46) > div.datetimepicker-hours > table > tbody > tr > td > span:nth-child(17)").Click();
                _chrome.FindElementByCssSelector("body > div:nth-child(46) > div.datetimepicker-minutes > table > tbody > tr > td > span:nth-child(9)").Click();
                Thread.Sleep(1000);
                //_chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div:nth-child(3) > div > input[type=\"file\"]").Click();
                _chrome.FindElementByCssSelector("#form-control > div > div:nth-child(3) > div > div.col-md-12.MarginGeral > div > button").Click();
                if (_chrome.Url.Contains("/Leilao/ListarLeiloes"))
                {
                    success += string.Format("Sucesso: Leilão Online criado com Sucesso {0}", Environment.NewLine);
                    _chrome.Close();
                }
                erro += string.Format("Erro: Não foi possivel criar leilão Online. Tela do erro na pasta Falhas {0}", Environment.NewLine);
                 var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "CriarLeilao.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
                _chrome.Close();
            }
            catch (Exception e)
            {
                erro += string.Format("Erro: Erro ao tentar criar leilão Online. Tela do erro na pasta Falhas {0}", Environment.NewLine);
               var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "CriarLeilao.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
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
                //Veiculos Cadastrados
                AjustClick.ClickById("qtdVeiculos", _chrome);
               

                if (_chrome.Url.Contains("Veiculo/ListarVeiculos"))
                {
                  success += string.Format("Sucesso: Link Quantidade de Veículos ok {0}", Environment.NewLine);

                }
                else
                {
                  erro += string.Format("Erro: Não foi possivel acessar o Link Quantidade de Veículos {0}", Environment.NewLine);
                }
                
                LoginBack();
                AjustClick.ClickById("qtdLeiloes", _chrome);
                if (_chrome.Url.Contains("Leilao/ListarLeiloes"))
                {
                   success += string.Format("Sucesso: Link Leilões ok {0}", Environment.NewLine);
                }
                else
                {
                    erro += string.Format("Erro: Não foi possivel acessar o Link Lista de Leilões {0}", Environment.NewLine);

                }
                LoginBack();
                AjustClick.ClickById("qtdUsuarios", _chrome);
                if (_chrome.Url.Contains("Usuario/ListarUsuarios"))
                {
                    success += string.Format("Sucesso: Link Lista de Usuarios ok{0}", Environment.NewLine);


                }
                else
                {
                    erro += string.Format("Erro: Não foi possivel acessar o Link Lista de Usuarios {0}", Environment.NewLine);
                }
                WritetextFile.SalvaTxtBk(success+"\n"+erro1);
                _chrome.Close();
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
