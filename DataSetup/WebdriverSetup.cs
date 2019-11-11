using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Collections.Generic;

namespace TigerSpike_SeleniumWebdriver_Demo.DataSetup
{
    public class WebdriverSetup
    {
        public static IWebDriver driver;

        TimeSpan commandTimeout = TimeSpan.FromSeconds(120);
        public static IWebDriver GetWebDriver()
        {
            return driver;
        }
       
        public void SetUp (string browserName)
        {         
            if (browserName.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else if(browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = commandTimeout;
            driver.Manage().Timeouts().ImplicitWait = commandTimeout;
            driver.Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();

        }

        [TearDown]
        public void TestTearDown()
        {
            driver.Close();
        }

        public static IEnumerable<string> BrowserOption()
        {
            string[] browsers = { "chrome", "firefox", "ie" };
            foreach (string b in browsers)
            {
                yield return b;
            }
        }
    }
}
