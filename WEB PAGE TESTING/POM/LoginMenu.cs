using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Overlay;
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

        string[] userData;
        string loginButton = "//input[@type='submit']";
        By emailInputFieldXpath = By.XPath("//input[@type='email']");
        By passwordInputFieldXpath = By.XPath("//input[@type='password']");

        public LoginMenu(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
            userData = System.IO.File.ReadAllLines(@"Prisijungimoduomenys.txt");
        }

        public void EnterEmailAndPassword()
        {
            driver.FindElement(emailInputFieldXpath).SendKeys(userData[1]); 
            driver.FindElement(passwordInputFieldXpath).SendKeys(userData[2]);
        }

        public void PressLoginButton()
        {
            generalMethods.ClickByJavaScript(loginButton);
        }

        public string ActualUserNameText => userData[0];
    }
}

