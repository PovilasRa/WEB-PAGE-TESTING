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

namespace WEB_PAGE_TESTING.TESTAVIMAS
{
    internal class _1A_Testas
    {
        private static string driverPath = "C:\\Users\\Mokymai\\Desktop\\chromedriver_win32\\chromedriver.exe";
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);

            //driver = new ChromeDriver(driverPath);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.1a.lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='cookie-btns']//a[@class='c-button']")).Click();
        }

        [Test]
        public static void loginTest()
        {

            TopMenu TopMenu = new TopMenu(driver);
            LoginMenu login = new LoginMenu(driver);

            TopMenu.clickLoginButton();
            login.enterMailPass();
            login.clickLoginButton();
            string name = "Testas";
            Assert.AreEqual(TopMenu.GetUserNameText(), name, "Wrong Name!!!!");
        }

        [Test]
        public static void productCardTest()
        {
            TopMenu TopMenu = new TopMenu(driver);
            ProductList productList = new ProductList(driver);
            ProductCard productCard = new ProductCard(driver);


            TopMenu.SearchByText("Iphone 11");
            productList.OpenFirstProduct();
            productCard.CheckBreadCrumb();
            productCard.CheckProductPrice();
            productCard.CheckProductFeaturesTable();
        }

        [Test]
        public static void priceSortingTest()
        {
            GeneralMethods general = new GeneralMethods(driver);
            ProductList productList = new ProductList(driver);

            general.Navigation("Buitinė", "Stambi", "Vandens šildytuvai");




        }
    }
}

