using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObject
{
    public class DemoSitesPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//button[contains(text(),'New Browser Tab')]")]
        private IWebElement buttonNewWindowTab;

        public DemoSitesPage(IWebDriver driver)
        {
            
        }

        public void NavigateToNewWindowTab()
        {
            
            buttonNewWindowTab.Click();
            //Thread.Sleep(5000);
        }

    }
}
