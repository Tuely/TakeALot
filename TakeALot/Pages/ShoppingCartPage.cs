using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TakeALot.CoreUI;
using TakeALot.Extensions;

namespace TakeALot.Pages
{
   public class ShoppingCartPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region Shopping Cart Page Elements
        [FindsBy(How = How.XPath, Using = "//form/*[@name='search']")]
        private IWebElement SearchText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Add to Cart')]")]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "badge-icon cart-icon")]
        private IWebElement ViewCartLink { get; set; }

        public bool ShoppingCartName(string value)
        {
            return _driverSupport.FindNewElement(By.XPath($"//h3[contains(text(), '{value}')]")).WaitUntilDisplayed();
        }
        #endregion

        #region Shopping Cart page Actions

        public void EnterSearchValue(string name)
        {
            WebElementExtension.EnterTextIntoField(SearchText, name);
        }

        public void AddToCart()
        {
            AddToCartButton.ClickElement();
        }

        public void ClickViewCartLink()
        {
            ViewCartLink.ClickElement();
        }
        public void VerifyCart(String name)
        {
            Assert.True(ShoppingCartName(name), $"Sucessfully Added shopping cart  with {name}");
        }
        #endregion
    }
}
