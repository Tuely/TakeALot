using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TakeALot.CoreUI;
using TakeALot.Extensions;

namespace TakeALot.Pages
{
  public  class HomePage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region Home Page Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Register')]")]
        private IWebElement RegisterLink { get; set; }

        #endregion

        #region Home Page Actions
        public void ClickRegisterLink()
        {
            RegisterLink.WaitUntilDisplayed(2);
            RegisterLink.ClickElement();
        }
        #endregion
    }
}
