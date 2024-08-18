using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AAUPG_JasnaPTrivunovic.POMs
{
    public class SignInPage : BasePage
    {
        public IWebElement LoginPopOverBtn => Wait.Until(
            SeleniumExtras.WaitHelpers
            .ExpectedConditions.ElementToBeClickable(By.Id("triggerLoginPopOver")));

        public IWebElement SignInForm => Wait.Until(
            SeleniumExtras.WaitHelpers
            .ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'bom-login-container')]//div[contains(text(), 'Login')]")));
        
        public IWebElement Username => Wait.Until(
            SeleniumExtras.WaitHelpers
            .ExpectedConditions.ElementIsVisible(By.Id("authentication_email")));
        
        public IWebElement Password => Wait.Until(
            SeleniumExtras.WaitHelpers
            .ExpectedConditions.ElementIsVisible(By.Id("authentication_password")));
        
        public IWebElement LoginBtn => Wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementToBeClickable(By.XPath("//button/span[contains(text(), 'Login')]")));
        
        public IWebElement ErrorMessage => Wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.XPath("//div[contains(@class, 'loggin-error-alert')]")));
        
        public IWebElement AcceptCookiesBtn => Wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementToBeClickable(By.Id("ensCloseBanner")));
        
        public IWebElement UserProfile => Wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions
            .ElementIsVisible(By.XPath("//span[@class='loginText']/span[@class='userName']")));
        
        public void NavigateToTravelodge() 
        {    
            Driver.Navigate().GoToUrl("https://www.travelodge.co.uk/");
            AcceptCookiesAndCheckIfModalIsGone();
        }            
        
        public bool IsSignInFormDisplayed() => SignInForm.Displayed;
        
        public void AcceptCookiesAndCheckIfModalIsGone()
        {
            AcceptCookiesBtn.Click();         
            Thread.Sleep(1000);
        }
        
        public void OpenLoginForm() => LoginPopOverBtn.Click();
        
        public void PerformSignIn(string email, string password)
        {         
            Username.SendKeys(email);
            Password.SendKeys(password);
            LoginBtn.Click();
        }

        public void WaitUntilLoginFormIsClosed() 
        {
            Wait.Until(ExpectedConditions.StalenessOf(SignInForm));
        }

        public void SuccessfulLogin() 
        {
            NavigateToTravelodge();
            OpenLoginForm();
            IsSignInFormDisplayed();
            PerformSignIn("lonom92292@iteradev.com", "Lonom92292!");
            WaitUntilLoginFormIsClosed();
        }
    }
}