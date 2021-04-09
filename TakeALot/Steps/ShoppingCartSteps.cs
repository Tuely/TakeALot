using System;
using TakeALot.Pages;
using TechTalk.SpecFlow;

namespace TakeALot.Steps
{
    [Binding]
    public class ShoppingCartSteps
    {
        private PageObjectFactory _page;
        public ShoppingCartSteps(PageObjectFactory page)
        {
            _page = page;
        }
        [Given(@"I search for '(.*)'")]
        public void GivenISearchFor(string name)
        {
            _page.ShoppingCartPage().EnterSearchValue(name);
        }

        [When(@"I add item into shopping bag")]
        public void WhenIAddItemIntoShoppingBag()
        {
            _page.ShoppingCartPage().AddToCart();
        }

        [Then(@"I verify '(.*)' item has been added to the cart")]
        public void ThenIVerifyItemHasBeenAddedToTheCart(string item)
        {
           
        }

    }
}
