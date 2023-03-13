using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class LoginMenu
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public LoginMenu(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void enterMailPass()
        {
            string email = "Testavimas@gmail.com";
            string password = "Testavimas";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 250)");
            By enterEmail = By.XPath("//input[@type='email']");
            driver.FindElement(enterEmail).SendKeys(email);
            By enterPassword = By.XPath("//input[@type='password']");
            driver.FindElement(enterPassword).SendKeys(password);
        }

        public void clickLoginButton()
        {
            By clickLoginTo = By.XPath("//input[@value='Prisijungti']");
            driver.FindElement(clickLoginTo).Click();
        }

    }
}

