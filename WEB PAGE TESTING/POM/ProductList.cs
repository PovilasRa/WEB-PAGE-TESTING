using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        string buttonPriceSortByXpath = "//div[contains(@class,\"desk\")]//span[@aria-readonly=\"true\"]";
        string buttonPriceMinToMaxXpath = "//span[@class='select2-results']//li[contains(text(),'Kaina nuo žemiausios')]";
        string priceXpath = "//div[contains(@class,'products-container')]//span[contains(@class,'item-price')]";
        string discountPriceXpath = "//div[contains(@class,'products-container')]//span[contains(@class,'price-number')]";
        string allPriceXpath = "(//div[@class='catalog-taxons-product__hover'])[]//span[contains(text(),'€')]";




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


        public void CheckPriceIsSortedMinToMax()
        {

            Thread.Sleep(1000);
            
            List<int> pricesWithoutDiscount = new List<int>();
            foreach (IWebElement element in driver.FindElements(By.XPath(priceXpath)))
            {
                string priceText = element.Text;
                string pricesSpliting = priceText.Replace(",", "");
                int prices = int.Parse(pricesSpliting);
                pricesWithoutDiscount.Add(prices);
            }

            List<int> discountPrices = new List<int>();
            foreach (IWebElement discountelement in driver.FindElements(By.XPath(discountPriceXpath)))
            {
                string discountPriceText = discountelement.Text;
                string trimmedPrices = discountPriceText.Substring(0, discountPriceText.Length - 2);
                string discountPriceSpliting = trimmedPrices.Replace(",", "");
                int pricesInInt = int.Parse(discountPriceSpliting);
                discountPrices.Add(pricesInInt);
            }

            //List<int> bothPrices = new List<int>();




            

            //for (int i = 0; i < pricesWithoutDiscount.Count-1; i++)
            //{
            //    if (pricesWithoutDiscount[i] >= pricesWithoutDiscount[i+1])
            //    {
            //        pricesWithoutDiscount[i]++;
            //    }
            //    else
            //    {
            //        Assert.Fail("Prices isnt sorted!");
            //    }
            //}

        }



        //(//div[@class="catalog-taxons-product__hover"])[5]//span[contains(text(),'€')] 
        // cia xpath kuris paima pagal euro zenkliuka pirma preke reiskia jei yra dvi kainos ims pirma

        //string productsWithBothPricesXpath = "//div[@class='catalog-taxons-product__hover']";


        public void checkPricesCount()
        {
            Thread.Sleep(10000);
            for (int i = 1; i <49; i++)
            {
                Console.WriteLine(getPrice(i));
                Console.WriteLine(driver.FindElements(By.XPath(getPrice(i))).Count);
            }
        }

        public string getPrice(int price)
        {
            return "(//div[@class=\"catalog-taxons-product__hover\"])[" + price +"]//span[contains(text(),'€')]";
        }

        public void writePrices()
        {
            Thread.Sleep(10000);
            for (int i = 1; i < 49; i++)
            {
                var price = driver.FindElements(By.XPath(getPrice(i)));
                if (price.Count == 1)
                {
                    Console.WriteLine(driver.FindElement(By.XPath("(//div[contains(@class,'products-container')]" +
                        "//span[contains(@class,'item-price')]/span[1])[" + i + "]")).Text);
                }

                else if (driver.FindElements(By.XPath(getPrice(i))).Count == 2)
                {
                    var priceWithDiscount = price[0].Text;
                    Console.WriteLine(priceWithDiscount);
                    //var eleentas2 = a[1].Text;
                    //Console.WriteLine(driver.FindElement(By.XPath("(//div[contains(@class,'products-container')]" +
                    //    "//span[contains(@class,'item-price')]/span[1])[" + i + "]")).Text);
                }

            }

        }




       
    }
}
