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

namespace FluxosTestes_Vip.Fluxo_Site
{
    [TestClass]
    public class FluxosCompletos_Site : PaginaBase

    {
        PaginaBase PaginaBase = new PaginaBase();
        QueryDAO QueryDAO = new QueryDAO();
        WritetextFile WritetextFile = new WritetextFile();
        private string _screenshotErro = ConfigurationManager.AppSettings["screenshotsPath"];
        private string driverPath = ConfigurationManager.AppSettings["chromedriverPath"];
        ChromeDriver _chrome;

        #region Construtor
        public FluxosCompletos_Site()
        {
            _chrome = new ChromeDriver();
        }
        #endregion

        #region Atributos
        public string Nome = "Paulo Ricardo";
        public string Apelido = "paulo";
        public string Email = "Paulo@gmail.com";
        public string Senha = "P123456";
        public string CPF = "14936166928";
        public string RG = "400107648";
        public string DtaRg = "20121990";
        public string Cel = "41995454672";
        public string tel = "9999999999";
        public string cep = "80010080";
        public string EndNumero = "226";
        public string EndCom = "Andar 9";
        public string ValorMin = "1000000";
        public string Valormax = "2000000";
        //links menu
        public string LinkDados = "MEUS DADOS";
        #endregion

        #region FechaChrome
        public void fecha()
        {
            _chrome.Close();
        }
        #endregion
        [TestMethod]
        public void FluxoTeste_Darlance()
        {
            try
            {
                Cadastro_Site();
                Login_Site();
                CadastroCompleto_Site();
                RealizaBuscas_Site();
                LanceCarro_Logado();
            }
            catch(Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\FinalizarCadastro_site.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }

        #region Metodos Pagina principal

        #region  Cadastro Dev
        public void Cadastro_Site()
        {
            try
            {
                NavegaDev(_chrome);
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#main-header > div > nav > ul > li:nth-child(3) > div > a:nth-child(3)").Click();
                //Preenche Campos
                _chrome.FindElementByCssSelector("#Nome").SendKeys(Nome);
                _chrome.FindElementByCssSelector("#Apelido").SendKeys(Apelido);
                _chrome.FindElementByCssSelector("#Email").SendKeys(Email);
                _chrome.FindElementByCssSelector("#ConfEmail").SendKeys(Email);
                _chrome.FindElementByCssSelector("#Cadeado").SendKeys(Senha);
                _chrome.FindElementByCssSelector("#contact_form > div > div:nth-child(11) > div > div > label").Click();
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#contact_form > div > div.col-md-6.col-md-offset-3 > button").Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\Cadastro_Hom.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }

        #endregion

        #region Login Dev 
        public void Login_Site()
        {
            try
            {
                NavegaDev(_chrome);
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#main-header > div > nav > ul > li:nth-child(3) > div > a:nth-child(3)").Click();
                //Preenche Campos
                _chrome.FindElementByCssSelector(" #contact_form > div > #Email").SendKeys(Email);
                _chrome.FindElementByCssSelector("#contact_form > div > div.col-md-6.nopadding > #Cadeado").SendKeys(Senha);
                _chrome.FindElementByXPath("//*[@id=\"contact_form\"]/div/div[2]/div/div/label").Click();
                _chrome.FindElementByCssSelector("#contact_form > div > div.col-md-4.col-md-offset-4 > button").Click();
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot(); ;
                s.SaveAsFile(_screenshotErro + "\\Login_Hom.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion

        #region Cadastro Final
        
        public void CadastroCompleto_Site()
        {
            try
            {
                NavegaDev(_chrome);
                Login_Site();
                _chrome.FindElementByCssSelector("#main-header > div > nav > ul > li:nth-child(3) > div > a").Click();
                // _chrome.FindElementByXPath("//*[@id=\"main - header\"]/div/nav/ul/li[3]/div/a");
                IList<IWebElement> menu = _chrome.FindElementsByCssSelector("#listing-cars > div.col-md-12.nopadding > div > div > div > ul > li > a");
               Thread.Sleep(1000);
                foreach (var ele in menu)
                {
                    if (ele.Text.Equals(LinkDados))
                    {
                        ele.Click();
                    }
                }
                Thread.Sleep(1000);
                //Preenche todos os dados
                _chrome.FindElementByCssSelector("#form-control > div:nth-child(2) > div > div > div:nth-child(3) > div:nth-child(1) > div > label").Click();
                Thread.Sleep(1000);
                _chrome.FindElementById("CPF").SendKeys(CPF);
                _chrome.FindElementById("RG").SendKeys(RG);
                _chrome.FindElementByCssSelector("#OrgaoExpedidor > option:nth-child(2)").Click();
                _chrome.FindElementById("dataExpedicao").SendKeys(DtaRg);
                _chrome.FindElementById("Celular").SendKeys(Cel);
                _chrome.FindElementById("Telefone").SendKeys(tel);
                Thread.Sleep(1000);
                AjustClear.ClearById("Endereco_CEP", _chrome);
                Thread.Sleep(1000);
                for (int i = 0; i < cep.Length; i++)
                {
                    IWebElement element = _chrome.FindElementById("Endereco_CEP");
                    string ele = cep.Substring(i, 1);
                    element.SendKeys(ele);
                    Thread.Sleep(10);
                 }
               // _chrome.FindElementById("Endereco_CEP").SendKeys(cep);
                Thread.Sleep(2000);
                _chrome.FindElementById("Endereco_Numero").SendKeys(EndNumero);
                Thread.Sleep(1000);
                _chrome.FindElementById("Endereco_Complemento").SendKeys(EndCom);
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#form-control > div.row.col-md-12.col-sm-12.col-xs-12.col-md-offset-4 > div > button").Click();
                //COnfirma E-mail
                QueryDAO.Update_email();
                //fecha();

            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\FinalizarCadastro_site.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion
 

        
        #region Realiza Buscas Dev
        [TestMethod]
        public void RealizaBuscas_Site()
        {
            try
            {
                NavegaDev(_chrome);
                // preenche marca do carro
                _chrome.FindElementByCssSelector("#ca\\20 MarcaCarro > option:nth-child(5)").Click();
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#ModeloCarro > option:nth-child(3)").Click();
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#AnoCarro > option:nth-child(2)").Click();
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#carros > div > div > div:nth-child(6) > div > button").Click();
                Thread.Sleep(1000);
                Wait(_chrome).Until(ExpectedConditions.UrlContains("Veiculos/ListarVeiculos"));
                PaginaBase.NavegaDev(_chrome);
                Thread.Sleep(1000);
                // Buscando por valor do veioculo
                AjustSendKeys.SendKeysById("ValorMinimoCarro", ValorMin, _chrome);
                AjustSendKeys.SendKeysById("ValorMaximoCarro", Valormax, _chrome);
                _chrome.FindElementByCssSelector("#carros > div > div > div:nth-child(6) > div > button").Click();
                Thread.Sleep(1000);
                Wait(_chrome).Until(ExpectedConditions.UrlContains("Veiculos/ListarVeiculos"));
                //fecha();


            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\RealizaBusca.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion

       
        #region Dar Lance Carro Deslogado DEV
        [TestMethod]
        public void LanceCarro_Desl()
        {
            try
            {
                NavegaDev(_chrome);
                _chrome.FindElementByCssSelector("#sidebar-menu-container > div > div.sidebar-menu-inner > section > div > div > div:nth-child(3) > div:nth-child(2) > div > a > div").Click();
                Thread.Sleep(1000);
                IWebElement valor = _chrome.FindElementByClassName("valorDetalhe");
                _chrome.FindElementByCssSelector("#lance_1").Click();
                IWebElement valor_Atual = _chrome.FindElementByClassName("valorDetalhe");
                if (valor.Text.Equals(valor_Atual.Text))
                {
                    //SalvarLog com erro
                    fecha();
                }
                fecha();

            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\Darlance_carro.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion

        #region Dar Lance Carro Logado DEV
        public void LanceCarro_Logado()
        {
            try
            {
                //NavegaDev(_chrome);
                //Login_Site();
                //Lance Minimo
                _chrome.FindElementByCssSelector("#sidebar-menu-container > div > div.sidebar-menu-inner > section > div > div > div:nth-child(3) > div:nth-child(2) > div > a > div").Click();
                Thread.Sleep(1000);
                IWebElement valor = _chrome.FindElementByClassName("valorDetalhe");
                _chrome.FindElementByCssSelector("#lance_1").Click();
                IWebElement Valorlance = _chrome.FindElementByCssSelector("#lance_1");
                IWebElement valor_Atual = _chrome.FindElementByClassName("valorDetalhe");
                if (valor.Text.Equals(valor_Atual.Text))
                {
                    string deuruim = "Erro: Realizado lance no valor "+Valorlance+"~leilão continua no valor "+valor+".";
                    WritetextFile.SalvaTxt(deuruim);
                }
                string deuboa = "Realizado lance com Sucesso";
                WritetextFile.SalvaTxt(deuboa);
            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\Darlance_carro.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion

        #region Agenda Leilão DEV
        [TestMethod]
        public void Agendaleilao_Site()
        {
            try
            {
                NavegaDev(_chrome);
                Thread.Sleep(1000);
                _chrome.FindElementByCssSelector("#main-header > div > nav > ul > li:nth-child(2)").Click();
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\Agendaleilao_Site.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion
        #endregion

        //Descontinuado 
        #region Testes Pagamentos


        //Descontinuado
        #region Teste pagamento basico
        [TestMethod]
        public void Planobasico()
        {
            try
            {
                NavegaDev(_chrome);
                Thread.Sleep(1000);
                //_chrome.FindElementByCssSelector("#revslider-52 > ul > li > div.tp_caption.slider_thumb.sfb.tp_resizeme.start.container.hidden-xs.hidden-sm > a").Click();
                //  _chrome.FindElementByClassName("btn_btnPerso").Click();
                IWebElement element = _chrome.FindElementByCssSelector("#revslider-52 > ul > li > div.tp-caption.slider-thumb.sfb.tp-resizeme.start.container.hidden-xs.hidden-sm > a");
                if(element.Text.Equals("QUERO VENDER"))
                {
                    element.Click();

                }
                Thread.Sleep(1000);
            }
            catch(Exception e)
            {
                var s = _chrome.GetScreenshot();
                s.SaveAsFile(_screenshotErro + "\\Planobasico.Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            }
        }
        #endregion



        #endregion


    }
}
