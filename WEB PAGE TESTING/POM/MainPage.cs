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

       

        public string Get1stCategoryListXpath(string firstcategoriename)
        {
            return "//ul[@class='submenu-lvl1__list']//a[contains(text(),'"+ firstcategoriename+"') and contains(@class,'submenu-lvl1')]";
        }

        public string Get2ndCategoryListXpath(string secondcategoriename)
        {
            return "//div[contains(@class,'only-desktop')]//a[contains(text(),'" + secondcategoriename + "')]";
        }

        public string Get3rdCategoryListXpath(string thirdcategoriename)
        {
            return "//div[contains(@class,'category-list')]//img[contains(@title,'"+thirdcategoriename+"')]";
        }
        

        public void NavigateTo(string categorie, string secondcategorie, string product)
        {
            generalMethods.ClickByJavaScript(Get1stCategoryListXpath(categorie));
            generalMethods.ClickByJavaScript(Get2ndCategoryListXpath(secondcategorie));
            generalMethods.ClickByJavaScript(Get3rdCategoryListXpath(product));

        }
    }
}
