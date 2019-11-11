using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TigerSpike_SeleniumWebdriver_Demo.Objects
{
    public class Payment
    {
        IWebDriver driver;

        WebDriverWait wait;

        public Payment(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        #region Page Elements
        By btnProceedToBuy = By.XPath("//a[@id='hlb-ptc-btn-native']");
        By txtAddressFullName = By.Id("enterAddressFullName");
        By txtAddressPhoneNumber = By.Id("enterAddressPhoneNumber");
        By txtAddressPinCode = By.Id("enterAddressPostalCode");
        By txtAddressLine1 = By.Id("enterAddressAddressLine1");
        By txtAddressLine2 = By.Id("enterAddressAddressLine2");
        By txtCity = By.Id("enterAddressCity");
        By txtState = By.Id("enterAddressStateOrRegion");
        By btnDeleteExistingAddress = By.XPath("//a[@class='a-button-text']");
        By btnContinue = By.XPath("//input[@value= 'Continue']");
        By invalidPhoneNumberErrorMessage = By.XPath("//p[contains(text(),'Please enter a valid 10 digit mobile number.')]");
        By confirmAddressContinueButton = By.XPath("//div[contains(@class,'a-row')]//div[1]//div[1]//span[1]//span[1]//input[1]");
        By txtPaymentHeader = By.XPath("//h1[contains(@class,'a-spacing-base')]");
        #endregion

        #region Action on Elements

        public void ClickProceedToPayButton()
        {
            driver.FindElement(btnProceedToBuy).Click();
        }

        public void SendAddressName(string name)
        {
            driver.FindElement(txtAddressFullName).SendKeys(name);
        }

        public void SendAddressPhobeNum(string phoneNum)
        {
            driver.FindElement(txtAddressPhoneNumber).SendKeys(phoneNum);
        }

        public void ClearPhoneNumberField()
        {
            driver.FindElement(txtAddressPhoneNumber).Clear();
        }

        public void SendAddress1(string addressLine1)
        {
            driver.FindElement(txtAddressLine1).SendKeys(addressLine1);
        }

        public void SendAddress2(string addressLine2)
        {
            driver.FindElement(txtAddressLine2).SendKeys(addressLine2);
        }

        public void SendCity(string addressCity)
        {
            driver.FindElement(txtCity).SendKeys(addressCity);
        }

        public void SendState(string addressState)
        {
            driver.FindElement(txtState).SendKeys(addressState);
        }

        public void AddressContinueButton()
        {
            driver.FindElement(btnContinue).Click();
        }

        public bool IsDefaultAddressPresent()
        {
            return driver.FindElement(btnDeleteExistingAddress).Displayed;
        }

        public void ClickExistingAddressDeleteOption()
        {
            driver.FindElement(btnDeleteExistingAddress).Click();
        }
        public void AddressPinCode(string pinCode)
        {
            driver.FindElement(txtAddressPinCode).SendKeys(pinCode);
        }
        public void ClickConfirmAddressContinueButton()
        {
            driver.FindElement(confirmAddressContinueButton).Click();
        }

        public string GetTextFieldHighlight(string Attribute)
        {
            return driver.FindElement(txtAddressPhoneNumber).GetCssValue(Attribute);
        }

        public string GetTextValidationError()
        {
            return driver.FindElement(invalidPhoneNumberErrorMessage).Text;
        }

        public string GetTextPaymentHeader()
        {
            return driver.FindElement(txtPaymentHeader).Text;
        }
        #endregion
    }
}
