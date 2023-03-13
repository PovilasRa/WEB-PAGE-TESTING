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
        string FirstProductXpath = "(//a[contains(@class,'product-image')])[1]";
        string ButtonPriceSortByXpath = "//span[contains(@class,'sort-icon')]";
        string ButtonPriceMinToMaxXpath = "";

        public ProductList(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void OpenFirstProduct()
        {
            generalMethods.ClickByJavaScript(FirstProductXpath);
        }


        public void ChoosePriceMinToMax()
        {
            generalMethods.ClickElementBy(ButtonPriceSortByXpath);
            generalMethods.ClickElementBy(ButtonPriceMinToMaxXpath);


        }


        public void CheckPriceIsSorted()
        {


        }
    }
}
