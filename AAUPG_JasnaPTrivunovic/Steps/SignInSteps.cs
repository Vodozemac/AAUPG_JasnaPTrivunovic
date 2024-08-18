using AAUPG_JasnaPTrivunovic.POMs;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AAUPG_JasnaPTrivunovic.Steps
{
    [Binding]
    public class SignInSteps
    {
        public SignInPage SignInPage;

        public SignInSteps()
        {
            SignInPage = new SignInPage();;
        }

        [Given(@"User navigates to Travelodge website")]
        public void GivenUserNavigatesToTravelodgeWebsite()
        {
            SignInPage.NavigateToTravelodge();
        }

        [When(@"user clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            SignInPage.OpenLoginForm();
        }

        [When(@"login form is displayed")]
        public void WhenLoginFormIsDisplayed()
        {
            Assert.True(SignInPage.IsSignInFormDisplayed());
        }

        [When(@"user enters valid email and password")]
        public void WhenUserEntersValidEmailAndPassword()
        {
            SignInPage.PerformSignIn("lonom92292@iteradev.com", "Lonom92292!");
        }

        [Then(@"user is successfuly signed in")]
        public void ThenUserIsSuccessfulySignedIn()
        {
            Assert.True(SignInPage.UserProfile.Displayed);
        }

        [When(@"user enters invalid email and password")]
        public void WhenUserEntersInvalidEmailAndPassword()
        {
            SignInPage.PerformSignIn("lonom92292@iteradev.com", "TestPass");
        }

        [Then(@"error message is displayed")]
        public void ThenErrorMessageIsDisplayed()
        {
            Assert.AreEqual("That email and password combination is not recognised. Please check and try again.", SignInPage.ErrorMessage.Text); 
        }
    }
}