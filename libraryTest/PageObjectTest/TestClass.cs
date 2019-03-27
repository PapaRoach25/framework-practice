// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject;

namespace PageObjectTest
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver;
        WebDriverWait webDriverWait;
        MainPage mainPage;
        DemoSitesPage demoSitesPage;


        [SetUp]
        public void SetUp()
        {
            //driver = DriverSingleton.Driver;
            driver = Browser.Driver();
            mainPage = new MainPage(driver);
            demoSitesPage = new DemoSitesPage(driver);
            driver.Manage().Window.Maximize();
            //webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //builder = new Actions(driver); 
        }

        [Test]
        public void OpenNewTab()
        {
            //driver.Url = "https://toolsqa.com";
            //IWebElement buttonDemoSites = driver.FindElement(By.XPath("(//span[text()='DEMO SITES'])[1]"));
            //builder.MoveToElement(mainPage.buttonDemoSites).Perform();

            //IWebElement ItemFromDemoSites = webDriverWait.Until(x => x.FindElement(By.XPath("(//span[text()='Automation Practice Switch Windows'])[1]")));
            //ItemFromDemoSites.Click();
            mainPage.Invoke();
            mainPage.NavigateToDemoSitesPage();
            string handler = driver.CurrentWindowHandle;

            //IWebElement buttonNewWindowTab = webDriverWait.Until( x => x.FindElement(By.XPath("//button[text()='New Browser Tab']")));
            //buttonNewWindowTab.Click();
            demoSitesPage.NavigateToNewWindowTab();
            var handles = driver.WindowHandles;
            var newTabHendler = handles.First(e => !e.Equals(handler));

            driver.SwitchTo().Window(newTabHendler);
            Assert.AreEqual(driver.Title, "QA Automation Tools Tutorial", "Not equals to title");
        }

        [Test]
        public void CheckTextInAlert()
        {
            driver.Url = "https://www.toolsqa.com/automation-practice-switch-windows/";
            IWebElement buttonTimingAlert = webDriverWait.Until(x => x.FindElement(By.CssSelector("#timingAlert")));
            buttonTimingAlert.Click();

            IAlert alert = webDriverWait.Until(e => e.SwitchTo().Alert());

            Assert.AreEqual(alert.Text, "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.", "Text in alert not equal to actual result");
        }

        [Test]
        public void Test()
        {
            driver.Url = "https://www.w3schools.com/hTml/html_iframe.asp";

            string handler = driver.CurrentWindowHandle;

            IWebElement frame = webDriverWait.Until(x => x.FindElement(By.XPath("//iframe[@src='default.asp']")));

            driver.SwitchTo().Frame(frame);
            IWebElement buttonNext = webDriverWait.Until(x => x.FindElement(By.XPath("//*[contains(@class, 'w3-right w3-btn')]")));
            buttonNext.Click();

            IWebElement title = driver.FindElement(By.XPath("//h1[contains(text(),'HTML')]/span[contains(text(),'Introduction')]"));
            string titleFrame = "HTML " + title.Text;

            Assert.AreEqual("HTML Iframes", driver.Title);
            Assert.AreEqual("HTML Introduction", titleFrame);

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
