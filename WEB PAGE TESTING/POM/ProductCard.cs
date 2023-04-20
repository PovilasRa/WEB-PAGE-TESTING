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

        string breadCrumbXpath = "//div[@itemscope='itemscope']//span[contains(@class,'breadcrumbs__item')]";
        string productPriceXpath = "//div[contains(@class,'product-price')]//span[@class='price']";
        string productFeatureXpath = "//div[@id='description-anchor']";
        string basketIconXpath = "//div[contains(@class,'product-controls')]//button[@name='button']";

        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void CheckBreadCrumbExist()
        {
            generalMethods.CheckElementIsVisible(breadCrumbXpath);
        }
        // Galima kabinėtis prie pavadinimu,
        // CheckProductPrice, nelabai ką sako
        // Aš tikėčiausi pamatęs tokį pavadinimą kad
        // Patikrins kainors teisingumą ar kažką iš tos serijos
        // Čia gal reikia kaip aukčiau ar Exist ar IsVisible pridėti
        // Bet vėl tiesiog pavadinimas..
        public void CheckProductPrice()
        {
            generalMethods.CheckElementIsVisible(productPriceXpath);
        }

        public void CheckBasketIcon()
        {
            generalMethods.CheckElementIsVisible(basketIconXpath);
        }

        public void CheckProductFeaturesTable()
        {
            generalMethods.CheckElementIsVisible(productFeatureXpath);
        }
    }
}

