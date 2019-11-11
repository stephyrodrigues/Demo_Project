using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TigerSpike_SeleniumWebdriver_Demo.Objects
{
    public class BestSellerPage
    {
        IWebDriver driver;

        WebDriverWait wait;

        public BestSellerPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        #region Page Elements

        By linkDepartmentBag = By.XPath("//a[contains(text(),'Bags, Wallets and Luggage')]");
        By linkBackPack = By.XPath("//ul[@id='zg_browseRoot']//ul//ul//a[contains(text(),'Backpacks')]");
        By txtTopBrandRanking = By.XPath("//span[@class = 'zg-badge-text']");
        By txtTopBrandNames = By.XPath("//div[@class = 'p13n-sc-truncated']");
        By btnAddToCart = By.XPath("//input[@id='add-to-cart-button']");
        By cartCount = By.XPath("//span[@id='nav-cart-count']");

        #endregion

        #region Action on Elements
        public void ClickBagDepartment()
        {
            driver.FindElement(linkDepartmentBag).Click();
        }

        public void ClickBackPack()
        {
            driver.FindElement(linkBackPack).Click();
        }
        #endregion

        public void ClickAddToCartButton()
        {
            driver.FindElement(btnAddToCart).Click();
        }

        public void GetBackBagsTop5Ranking()
        {
            
            List<string> getTop5RankListText = new List<string>();
            List<string> getTopBrandListNameText = new List<string>();
            IList<IWebElement> rankList = driver.FindElements(txtTopBrandRanking);
            IList<IWebElement> rankListBrandNames = driver.FindElements(txtTopBrandNames);
            foreach(IWebElement element in rankList)
            {
                    getTop5RankListText.Add(element.Text);               
                
            }

            for(int i =0; i<5; i++)
            {
                if(getTop5RankListText[i].Contains("#1")| getTop5RankListText[i].Contains("#2")| getTop5RankListText[i].Contains("#3")| getTop5RankListText[i].Contains("#4")| getTop5RankListText[i].Contains("#5"))
                {
                    getTopBrandListNameText.Add(rankListBrandNames[i].Text);
                }
               
            }

            if(getTopBrandListNameText.Count <5)
            {
                Assert.Fail();
            }

        }

        public void ChooseTopBrandBackPack()
        {
            IList<IWebElement> rankListText = driver.FindElements(txtTopBrandNames);
            rankListText[0].Click();
        }

        public void ClickOnAddToCartButton()
        {
            driver.FindElement(btnAddToCart).Click();
        }

        public string GetCartCount()
        {
            return driver.FindElement(cartCount).Text;
        }
    }

}
