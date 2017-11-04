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
        [TestMethod]
        public void TestAutenticacion()
        {
            String url = "http://localhost:50272/Autenticacion.aspx";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("textUsername")).SendKeys("jefalva@live.com");
            driver.FindElement(By.Id("textPassword")).SendKeys("102961");
            driver.FindElement(By.Id("Button1")).Click();
            driver.Close();
            driver.Dispose();
        }
    }
}
