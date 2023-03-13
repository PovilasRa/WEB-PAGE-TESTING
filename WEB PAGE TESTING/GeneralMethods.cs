using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING
{
    public class GeneralMethods
    {
        IWebDriver driver;
        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickElementBy(string xpath)
        {

            IWebElement el = driver.FindElement(By.XPath(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
        public void EnterTextBy(string xpath, string text)
        {
            By searchField = By.XPath(xpath);
            driver.FindElement(searchField).SendKeys(text);
        }

        public void HoverAndCLickBy(string xpath)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(xpath))).Perform();
            driver.FindElement(By.XPath(xpath)).Click();

        }

        public void ClickByJavaScript(string xpath)
        {
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            javascriptExecutor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath(xpath)));
        }


        public void CheckElementIsVisible(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException($"Element whoose xpath is:  '{xpath}', not found.");
            }
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

        public void PriceSortingMinToMax()
        {

        }


    }
}

