using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class ProductList
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        string firstProductXpath = "(//a[contains(@class,'product-image')])[1]";
        string buttonPriceSortByXpath = "//div[contains(@class,'desk')]//span[@aria-readonly='true']";
        string buttonPriceMinToMaxXpath = "//span[@class='select2-results']//li[contains(text(),'Kaina nuo žemiausios')]";

        public ProductList(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void OpenFirstProduct()
        {
            generalMethods.ClickByJavaScript(firstProductXpath);
        }

        public void ChoosePriceMinToMax()
        {
            generalMethods.ClickElementBy(buttonPriceSortByXpath);
            generalMethods.ClickElementBy(buttonPriceMinToMaxXpath);
        }

        public string GetPrice(int price)
        {
            return "(//div[@class=\"catalog-taxons-product__hover\"])[" + price +"]//span[contains(text(),'€')]";
        }

        private double ParsePrice(string from)
        {
            var split = from.Split(' ')[0];
            return double.Parse(split.Replace(',', '.'));
        }

        public List<double> GetPriceList()
        {
            var allPricesList = new List<double>();
            Thread.Sleep(3000);
            for (int i = 1; i < 49; i++)
            {
                var price = driver.FindElements(By.XPath(GetPrice(i)));
                if (price.Count == 1)
                {
                    allPricesList.Add(ParsePrice(driver.FindElement(By.XPath("(//div[contains(@class,'products-container')]" +
                        "//span[contains(@class,'item-price')]/span[1])[" + i + "]")).Text));
                    
                }

                else if (driver.FindElements(By.XPath(GetPrice(i))).Count == 2)
                {
                    var priceWithDiscount = price[0].Text;
                    allPricesList.Add(ParsePrice(priceWithDiscount));
                    
                }
            }
            return allPricesList;
        }

        public void CheckListSortedMinToMax()
        {
            var sarasas = GetPriceList();
            for (int i = 1; i < sarasas.Count; i++)
            {
                if (sarasas[i - 1] > sarasas[i])
                {
                    Assert.Fail("Price isn't sorted!!!!");
                }
            }
        }
    }
}
