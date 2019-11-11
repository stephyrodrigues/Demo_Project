using NUnit.Framework;
using excel = Microsoft.Office.Interop.Excel;
using TigerSpike_SeleniumWebdriver_Demo.DataSetup;
using TigerSpike_SeleniumWebdriver_Demo.Objects;
using System.Threading;

namespace TigerSpike_SeleniumWebdriver_Demo.Scripts
{
    [TestFixture]
    public class AmazonOrderFunctionality  
    {        
        WebdriverSetup driverSetUp = new WebdriverSetup();

        [Test]
        [TestCaseSource(typeof(WebdriverSetup), "BrowserOption")]
        public void VerifyAmazonOrderFunctionality(string browserName)
        {
            driverSetUp.SetUp(browserName);//SetUp of Cross Browser and URL
            Payment payment = new Payment(WebdriverSetup.GetWebDriver());
            DashboardPage dashboardPage = new DashboardPage(WebdriverSetup.GetWebDriver());
            BestSellerPage bestSellerPage = new BestSellerPage(WebdriverSetup.GetWebDriver());
            dashboardPage.ClickBestSellerBtn();//BestSeller Option Click
            bestSellerPage.ClickBagDepartment();// Choosing of Department
            bestSellerPage.ClickBackPack();// Choosing of Category
            bestSellerPage.GetBackBagsTop5Ranking();// Getting top 5 Brands
            bestSellerPage.ChooseTopBrandBackPack(); //Choosing Brand
            bestSellerPage.ClickAddToCartButton(); // Adding to Cart
            string getCartCountUI = bestSellerPage.GetCartCount(); 
            if(getCartCountUI.Equals("1"))// Validating Cart Count
            {
                payment.ClickProceedToPayButton();
            }
            else
            {
                Assert.Fail();
            }

            //Login(Passing Login Credentials through Excel
            excel.Application xlapp = new excel.Application();
            excel.Workbook xlworkbook = xlapp.Workbooks.Open(@"C:\Users\stephy.rodrigues\Source\Repos\TigerSpike_SeleniumWebdriver_Demo\Configuration\LoginData.xlsx");
            excel.Worksheet xlworksheet = xlworkbook.Sheets[1];
            excel.Range xlrange = xlworksheet.UsedRange;

            double userName;
            string passWord;
            userName = xlrange.Cells[1][1].value;
            passWord = xlrange.Cells[2][1].value;
            dashboardPage.SendUserName(userName.ToString());
            dashboardPage.ClickContinueButton();
            dashboardPage.SendPassword(passWord);
            dashboardPage.ClickLoginButton();//Completed Login

            bool value = payment.IsDefaultAddressPresent();
            if(value == true)
            {
                payment.ClickExistingAddressDeleteOption();//Deleting Existing defauld address if any
            }
            //Passing Values to address Fields
            payment.SendAddressName("TestName");
            payment.ClearPhoneNumberField();
            payment.SendAddressPhobeNum("56765456".ToString());
            payment.AddressPinCode("560035");
            payment.SendAddress1("#2, Rk Homes");
            payment.SendAddress2("Carmelaram");
            payment.SendCity("Bengaluru");
            payment.SendState("Karnataka");
            payment.AddressContinueButton();
            string phoneValidationErrorUI = payment.GetTextValidationError();
            Assert.AreEqual(phoneValidationErrorUI, "Please enter a valid 10 digit mobile number.");//Validation Check for invalid Phone number
            payment.ClearPhoneNumberField();//Clearing Phone Number Field to enter Vlaid Phone Number
            payment.SendAddressPhobeNum("8765676543");
            payment.AddressContinueButton();
            payment.ClickConfirmAddressContinueButton();//Confirming Address
            Thread.Sleep(5000);
            string getPaymentHeaderText = payment.GetTextPaymentHeader();//Verifying Payment Selection page header
            Assert.AreEqual(getPaymentHeaderText, "Select a payment method");
        }




    }
}
