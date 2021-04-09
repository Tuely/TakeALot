using System;
using TakeALot.CoreUI;
using TakeALot.Pages;
using TechTalk.SpecFlow;

namespace TakeALot.Steps
{
    [Binding]
    public class RegisterationSteps
    {
        private PageObjectFactory _page;
        public RegisterationSteps(PageObjectFactory page)
        {
            _page = page;
        }
        #region Given Scenarios
        [Given(@"I navigate into Take a lot")]
        public void GivenINavigateIntoTakeALot()
        {
            BasePage.NavigateToUrl(AppConfigManager.BaseUrl());
        }

        [Given(@"I click Register Link")]
        public void GivenIClickRegisterLink()
        {
            _page.HomePage().ClickRegisterLink();
        }

        #endregion

        [When(@"I enter registartion details as '(.*)', '(.*)', '(.*)' , '(.*)', '(.*)'")]
        public void WhenIEnterRegistartionDetailsAs(string fname, string lname, string email, string password, string mobile)
        {
            _page.RegisterPage().RegisterDetails(fname, lname, email, password, mobile);
        }
        [Then(@"I verify the user is registered")]
        public void ThenIVerifyTheUserIsRegistered()
        {
            _page.RegisterPage().VerifyRegistrationMessage();
        }

    }
}
