using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class MainPage
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void Navigation(string categorie, string secondcategorie, string product)
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;


            string categorieName = ("//div[contains(@class,'site-block welcome')]//a[contains(text(),'" + categorie + "')]");
            try
            {
                javascriptExecutor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(categorieName)));
            }
            catch (Exception)
            {
                throw new Exception($"Element whoose xpath is:  '{categorieName}', not found.");
            }

            string secondCategorieName = ("//ul[contains(@class,'new-cat-list')]//span[contains(text(),'" + secondcategorie + "')]");
            try
            {
                javascriptExecutor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(secondCategorieName)));
            }
            catch (Exception)
            {
                throw new Exception($"Element whoose xpath is:  '{secondCategorieName}', not found.");
            }

            string productName = ("//ul[@class='child-category']//a[contains(text(),'" + product + "')]");
            try
            {
                javascriptExecutor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(productName)));
            }
            catch (Exception)
            {
                throw new Exception($"Element whoose xpath is:  '{product}', not found.");
            }

        }
    }
}
