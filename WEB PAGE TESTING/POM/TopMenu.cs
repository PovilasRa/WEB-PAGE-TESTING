using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class TopMenu
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        string searchFieldXpath = "//input[contains(@class,'main-search-input') and @autocomplete=\"off\"]";
        string searchButtonXpath = "//div[@class=\"main-search__submit\"]";
        public TopMenu(IWebDriver driver) 
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void SearchByText(string text)
        {
            generalMethods.EnterTextBy(searchFieldXpath, text);
            generalMethods.ClickElementBy(searchButtonXpath);
        }
        public void ClickLoginButton()
        {
            By loginButton = By.XPath("//strong[contains(@class,'user-block__title')]");
            driver.FindElement(loginButton).Click();
        }
        public string GetUserNameText()
        {
            By userName = By.XPath("//strong[contains(@class,'user-block')]");
            string userNameText = driver.FindElement(userName).Text;
            return userNameText;
        }
    }
}
