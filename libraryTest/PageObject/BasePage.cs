using driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get { return Browser.Driver(); } }
        public Actions _builder;
        public static WebDriverWait _webDriverWait;

        public BasePage()
        {
            _webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            _builder = new Actions(Driver);
            PageFactory.InitElements(Driver, this);
        }

       


    }
}
