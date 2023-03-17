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

        TopMenu topMenu;
        ProductList productList;
        ProductCard productCard;
        MainPage mainPage;
        LoginMenu loginMenu;

        [SetUp]
        public void SETUP()
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

            topMenu = new TopMenu(driver);
            productList = new ProductList(driver);
            productCard = new ProductCard(driver);
            mainPage = new MainPage(driver);
            loginMenu = new LoginMenu(driver);
        }

        [Test]
        public void LoginTest()
        {

            topMenu.ClickLoginButton();
            loginMenu.EnterEmailAndPassword();
            loginMenu.PressLoginButton();
            loginMenu.ActualUserNameText();
            Assert.AreEqual(topMenu.GetUserNameText(), loginMenu.ActualUserNameText(), "Wrong Name!!!!");
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
        public void PriceSortingTest()
        {
           
            mainPage.NavigateTo("Buitinė", "Stambi", "Vandens šildytuvai");
            productList.ChoosePriceMinToMax();


            //reiktu pasidaryt du atskirus xpath tikrai kainai ir kainai su nuolaida ir tada rasyti
            //kad jeigu prekeje yra dvi kainos imk kazkuria kaina kurios tau reikia
        }
    }
}

