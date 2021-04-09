using TakeALot.CoreUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeALot.Pages
{
  public  class PageObjectFactory
    {
        public IWebDriver _driver;
        public BasePage _basePage;
        public PageObjectFactory(IWebDriver driver, BasePage basePage)
        {
            _driver = driver;
            _basePage = basePage;
        }

        public HomePage HomePage()
        {
            return _basePage.GetPage<HomePage>(_driver);
        }

        public RegisterPage RegisterPage()
        {
            return _basePage.GetPage<RegisterPage>(_driver);
        }

        public ShoppingCartPage ShoppingCartPage()
        {
            return _basePage.GetPage<ShoppingCartPage>(_driver);
        }
    }
}
