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

       

        public string Get1stCategoryListXpath(string firstcategorielist)
        {
            return "//ul[contains(@class,'submenu')]//a[contains(text(),'"+ firstcategorielist+"')]";
        }

        public string Get2ndCategoryListXpath(string secondcategorielist)
        {
            return "//div[contains(@class,'only-desktop')]//a[contains(text(),'" + secondcategorielist + "')]";
        }

        public string Get3rdCategoryListXpath(string thirdcategorielist)
        {
            return "//ul[@class='child-category']//a[contains(text(),'" + thirdcategorielist + "')";
        }
        

        public void NavigateTo(string categorie, string secondcategorie, string product)
        {
            generalMethods.ClickElementBy(Get1stCategoryListXpath(categorie));
            generalMethods.ClickElementBy(Get2ndCategoryListXpath(secondcategorie));
            generalMethods.ClickElementBy(Get3rdCategoryListXpath(product));

        }
    }
}
