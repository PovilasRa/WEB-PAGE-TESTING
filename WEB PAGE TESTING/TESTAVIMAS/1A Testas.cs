using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEB_PAGE_TESTING.POM;
using OpenQA.Selenium.Interactions;
using System.IO;
using NUnit.Framework.Interfaces;

namespace WEB_PAGE_TESTING.TESTAVIMAS
{
    internal class _1A_Testas
    {
        //private static string driverPath = "C:\\Users\\Mokymai\\Desktop\\chromedriver_win32\\chromedriver.exe";
        static IWebDriver driver;

        TopMenu topMenu;
        ProductList productList;
        ProductCard productCard;
        MainPage mainPage;
        LoginMenu loginMenu;
        GeneralMethods generalMethods;

        [SetUp]
        public void SetUp()
        {
            driver = GeneralMethods.CreateDriverWithoutNotification();
           
            topMenu = new TopMenu(driver);
            productList = new ProductList(driver);
            productCard = new ProductCard(driver);
            mainPage = new MainPage(driver);
            loginMenu = new LoginMenu(driver);
            generalMethods = new GeneralMethods(driver);

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.1a.lt/";
            // Thread sleep todėl, kad juda mygtukas ir nevisada spaudžia bei failina testas.
            Thread.Sleep(1000); 
            generalMethods.WaitElement("//div[@id='cookie-btns']//a[@class='c-button']", driver).Click();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var name =
                    $"{TestContext.CurrentContext.Test.MethodName}" +
                    $" Error at " +
                    $"{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")}";

                GeneralMethods.TakeScreenShot(driver, name);

                File.WriteAllText(
                    $"Screenshots\\{name}.txt",
                    TestContext.CurrentContext.Result.Message);
            }
            driver.Quit();
        }
           
        [Test]
        public void LoginTest()
        { 
            topMenu.ClickLoginButton();
            loginMenu.EnterEmailAndPassword();
            loginMenu.PressLoginButton();
            Assert.AreEqual(topMenu.GetUserNameText(), loginMenu.ActualUserNameText, "Wrong Name!!!!");
        }

        [Test]
        public void ProductCardTest()
        {
            topMenu.SearchByText("Iphone 11");
            productList.OpenFirstProduct();
            productCard.CheckBreadCrumbExist();
            productCard.CheckProductPrice();
            productCard.CheckBasketIcon();
            productCard.CheckProductFeaturesTable();
        }

        [Test]
        public void PriceSortingMinToMaxTest()
        {
            mainPage.NavigateTo("Buitinė", "Stambi", "Vandens šildytuvai");
            productList.ChoosePriceMinToMax();
            productList.getPriceList();
            productList.checkListSortedMinToMax();
        }
    }
}

