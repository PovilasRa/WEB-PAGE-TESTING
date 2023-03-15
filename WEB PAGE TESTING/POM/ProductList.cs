using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class ProductList
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        string firstProductXpath = "(//a[contains(@class,'product-image')])[1]";
        string buttonPriceSortByXpath = "//span[contains(@class,'sort-icon')]";
        string buttonPriceMinToMaxXpath = "";

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


        public void CheckPriceIsSorted()
        {


        }
    }
}
