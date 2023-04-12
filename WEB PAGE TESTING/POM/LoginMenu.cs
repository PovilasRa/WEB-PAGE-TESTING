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
        public LoginMenu(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        string[] userdata = System.IO.File.ReadAllLines(@"Prisijungimoduomenys.txt");

        public void EnterEmailAndPassword()
        {
            By enterEmail = By.XPath("//input[@type='email']");
            driver.FindElement(enterEmail).SendKeys(userdata[1]);
            By enterPassword = By.XPath("//input[@type='password']");
            driver.FindElement(enterPassword).SendKeys(userdata[2]);
        }

        public void PressLoginButton()
        {
            string loginButton = "//input[@type='submit']";
            generalMethods.ClickByJavaScript(loginButton);
        }

        public string ActualUserNameText()
        {
            return userdata[0];
        }
    }
}

