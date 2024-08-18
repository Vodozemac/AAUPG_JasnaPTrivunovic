using AAUPG_JasnaPTrivunovic.POMs;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AAUPG_JasnaPTrivunovic.Steps
{
    [Binding]
    public class SearchSteps
    {
        public SignInPage SignInPage;
        public SearchPage SearchPage;
        public SearchSteps()
        {
            SignInPage = new SignInPage();
            SearchPage = new SearchPage();
        }

        [Given(@"User is successfuly logged in")]
        public void GivenUserIsSuccessfulyLoggedIn()
        {
            SignInPage.SuccessfulLogin();
        }

        [When(@"User enters '([^']*)' in Destination field")]
        public void WhenUserEntersInDestinationField(string destination)
        {
            SearchPage.DestinationInput.SendKeys(destination);
        }

        [When(@"clicks on Search button")]
        public void WhenClicksOnSearchButton()
        {
            SearchPage.SearchBtn.Click();
        }

        [Then(@"search results for '([^']*)' are displayed")]
        public void ThenSearchResultsForAreDisplayed(string location)
        {
            string expectedUrlPart = $"/search/results?location={location}";
            Assert.True(SearchPage.IsUrlContaining(expectedUrlPart));
        }

        [Then(@"User is able to iterate through carussel content")]
        public void ThenUserIsAbleToIterateThroughContent()
        {
            SearchPage.IterateThroughCarousel();
        }

        [Then(@"Choose promotion '([^']*)'")]
        public void ThenChoosePromotion(string promotionTitle)
        {
            SearchPage.OpenPromotion(promotionTitle);
        }

        [Then(@"User is redirected to '([^']*)' web page")]
        public void ThenUserIsRedirectedToWebPage(string urlPart)
        {
            Assert.True(SearchPage.IsUrlContaining(urlPart));
        }
    }
}