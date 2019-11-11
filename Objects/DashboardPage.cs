using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TigerSpike_SeleniumWebdriver_Demo.Objects
{
    public class DashboardPage 
    {
        IWebDriver driver;

        WebDriverWait wait;

        public DashboardPage(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        #region Page Elements

        By drpDownSignIn = By.XPath("//span[contains(text(),'Hello. Sign in')]");
        By signInButton = By.XPath("//div[@id='nav-flyout-ya-signin']//span[@class='nav-action-inner'][contains(text(),'Sign in')]");
        By btnBestSeller = By.XPath("//a[contains(text(),'Best Sellers')]");
        By txtUsername = By.XPath("//input[@id='ap_email']");
        By btnContinue = By.XPath("//input[@id='continue']");
        By txtPassword = By.XPath("//input[@id='ap_password']");
        By btnLogin = By.XPath("//input[@id='signInSubmit']");


        #endregion

        #region Action on Elements
        public void ClickBestSellerBtn()
        {
            driver.FindElement(btnBestSeller).Click();
        }

        public void ClickSignInDropDown()
        {
            driver.FindElement(drpDownSignIn).Click();
        }

        public void ClickSignInButton()
        {
            driver.FindElement(signInButton).Click();
        }

        public void SendUserName(string userName)
        {
            driver.FindElement(txtUsername).SendKeys(userName);
        }

        public void ClickContinueButton()
        {
            driver.FindElement(btnContinue).Click();
        }

        public void SendPassword(string passWord)
        {
            driver.FindElement(txtPassword).SendKeys(passWord);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(btnLogin).Click();
        }
        #endregion
    }
}
