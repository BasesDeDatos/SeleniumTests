using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class Tests
    {
        static IWebDriver driver = new ChromeDriver();
        static WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

        [TestMethod]
        public void Registro_CorreoRepetido_Registro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalva@live.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("Registrar")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void Registro_PassInvalido_NoRegistro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalvaq@live.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("1029");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("1029");
            driver.FindElement(By.Id("Registrar")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void Registro_PassNoCoincide_NoRegistro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalvaq@live.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("102912");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("102913");
            driver.FindElement(By.Id("Registrar")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void Registro_CorreoInvalido_NoRegistro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalvalive.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("Registrar")).Click();
            driver.FindElement(By.CssSelector("input:invalid"));
        }

        [TestMethod]
        public void Registro_NoCorreo_NoRegistro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("1029612");
            driver.FindElement(By.Id("Registrar")).Click();
            driver.FindElement(By.CssSelector("input:invalid"));
        }

        [TestMethod]
        public void Registro_NoPass_NoRegistro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalvalive@live.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("");
            driver.FindElement(By.Id("Registrar")).Click();
            //driver.FindElement(By.CssSelector("input:invalid"));
            wait.Until(wt => wt.FindElement(By.CssSelector("input:invalid")));
        }

        /*
        [TestMethod]
        public void Registro_DatosValidos_Registro()
        {
            String url = "http://localhost:50272/Registro.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("correoUsuarioRegistrar")).SendKeys("jefalvalive@live.com");
            driver.FindElement(By.Id("contrasenaRegistrar")).SendKeys("12345678");
            driver.FindElement(By.Id("contrasenaConfirmarRegistrar")).SendKeys("12345678");
            driver.FindElement(By.Id("Registrar")).Click();
            wait.Until(wt => wt.FindElement(By.Id("textUsername")));
        }
        */

        [TestMethod]
        public void Autenticacion_CredencialesInvalidas_NoLogin()
        {
            String url = "http://localhost:50272/Autenticacion.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("textUsername")).SendKeys("jefalva@live.com");
            driver.FindElement(By.Id("textPassword")).SendKeys("102962");
            driver.FindElement(By.Id("Button1")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        [TestMethod]
        public void Autenticacion_CredencialesValidas_Login()
        {
            String url = "http://localhost:50272/Autenticacion.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("textUsername")).SendKeys("jefalva@live.com");
            driver.FindElement(By.Id("textPassword")).SendKeys("1029612");
            driver.FindElement(By.Id("Button1")).Click();
            wait.Until(wt => wt.FindElement(By.Id("mymodal")));
        }

        [TestMethod]
        public void Persona_CredencialesValidas_Login()
        {
            String url = "http://localhost:50272/Autenticacion.aspx";
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("textUsername")).SendKeys("jefalva@live.com");
            driver.FindElement(By.Id("textPassword")).SendKeys("1029612");
            driver.FindElement(By.Id("Button1")).Click();
            wait.Until(wt => wt.FindElement(By.Id("mymodal")));
        }
    }
}
