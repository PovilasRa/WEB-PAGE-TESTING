using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_PAGE_TESTING.POM
{
    internal class ProductCard
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        string BreadCrumbXpath = "//div[@itemscope='itemscope']//span[contains(@class,'breadcrumbs__item')]";
        string ProductPriceXpath = "//div[contains(@class,'product-price')]//span[@class=\"price\"]";
        string ProductFeatureXpath = "//div[@id='description-anchor']";

        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void CheckBreadCrumb()
        {
            generalMethods.CheckElementIsVisible(BreadCrumbXpath);
        }
        public void CheckProductPrice()
        {
            generalMethods.CheckElementIsVisible(ProductPriceXpath);
        }
        public void CheckProductFeaturesTable()
        {
            generalMethods.CheckElementIsVisible(ProductFeatureXpath);

        }

    }
}

