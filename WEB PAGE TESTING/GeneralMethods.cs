using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;
using System.IO;

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
            var element = WaitElement(xpath, driver); 

            try
            {
                IWebElement el = driver.FindElement(By.XPath(xpath));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", el, element);
                el.Click();
            }
            catch (Exception)
            {
                throw new Exception($"Element whoose xpath is:  '{xpath}', not found.");
            }
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
            var element = WaitElement(xpath, driver);
            javascriptExecutor.ExecuteScript("arguments[0].click();", element);
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

        public IWebElement WaitElement(string xPath, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromSeconds(0.5);
            return wait.Until(d => d.FindElement(By.XPath(xPath)));
        }

        public static IWebDriver CreateDriverWithoutNotification()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            return new ChromeDriver(options);
        }

        public static void TakeScreenShot(IWebDriver driver, string fileName)
        {
            var screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            if (!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }

            screenshot.SaveAsFile(
                $"Screenshots\\{fileName}.png",
                ScreenshotImageFormat.Png);
        }
    }
}
