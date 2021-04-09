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
    public class RegisterPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region Registration Page Elements
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement UserNameText { get; set; }

        [FindsBy(How = How.Id, Using = "surname")]
        private IWebElement LastNameText { get; set; }
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailText { get; set; }
        [FindsBy(How = How.Id, Using = "email2")]
        private IWebElement Email2Text { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordText { get; set; }
        [FindsBy(How = How.Id, Using = "password2")]
        private IWebElement Password2Text { get; set; }
        [FindsBy(How = How.Id, Using = "telno1")]
        private IWebElement MobileText { get; set; }
        [FindsBy(How = How.Name, Using = "registerButton")]
        private IWebElement RegisterButton { get; set; }
        [FindsBy(How = How.Id, Using = "welcome")]
        private IWebElement RegistrationMessage { get; set; }
        
        #endregion

        #region Registration Page Actions

        public void RegisterDetails(string fname, string lname, string email, string password, string mobile)
        {
        WebElementExtension.EnterTextIntoField(UserNameText, fname);
            WebElementExtension.EnterTextIntoField(LastNameText, lname);
            WebElementExtension.EnterTextIntoField(EmailText, email+DateTime.Now.ToString("ddmmyyhhmm")+"@test.com");
            WebElementExtension.EnterTextIntoField(Email2Text, email+DateTime.Now.ToString("ddmmyyhhmm")+ "@test.com");
            WebElementExtension.EnterTextIntoField(PasswordText, password);
            WebElementExtension.EnterTextIntoField(Password2Text, password);
            WebElementExtension.EnterTextIntoField(MobileText, mobile);
            RegisterButton.ClickElement();
        }

        public void VerifyRegistrationMessage()
        {
            Assert.That(RegistrationMessage.WaitUntilDisplayed(5),
                Is.EqualTo(true), "User has been regostered sucessfully");
        }
        #endregion
    }
}
