using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driver
{
    public class Browser
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver()
        {
            _driver = _driver ?? new ChromeDriver();
            return _driver;
        }

        public static void CloseDriver()
        {
            if (_driver != null) _driver.Quit();
        }

        static readonly Finalizer finalizer = new Finalizer();

        sealed class Finalizer
        {
            ~Finalizer()
            {
                CloseDriver();
            }
        }
    }
}
