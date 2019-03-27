using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObject
{
    public class MainPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "(//span[text()='DEMO SITES'])[1]")]
        private IWebElement buttonDemoSites;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Automation Practice Switch Windows'])[1]")]
        private IWebElement ItemFromDemoSites;

        public MainPage(IWebDriver driver)
        {
            
        }
        public void WaitButtonDemoSites()
        {
            //_webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy((By)buttonDemoSites));
            // Perform desired actions that you wanted to do in myClass
        }
        public void NavigateToDemoSitesPage()
        {
            //_webDriverWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            //_webDriverWait.Timeout = TimeSpan.FromMilliseconds(5000);
            //_webDriverWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            //_webDriverWait.Until(ExpectedConditions.ElementIsVisible(buttonDemoSites));
            //_webDriverWait.Until(ExpectedConditions.ElementIsVisible());
            
            _builder.MoveToElement(buttonDemoSites).Perform();
            //Thread.Sleep(8000);
            _webDriverWait.Until(x => x.FindElement(By.XPath("(//span[text()='Automation Practice Switch Windows'])[1]")));
            _builder.MoveToElement(ItemFromDemoSites).Click().Build().Perform();
            
            //ItemFromDemoSites.Click();
           // Thread.Sleep(5000);
        }
        public void Invoke()
        {
            Driver.Navigate().GoToUrl(@"https://toolsqa.com");
        }


    }
}
