using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AAUPG_JasnaPTrivunovic.POMs
{
    public class SearchPage : BasePage
    {
           public IWebElement DestinationInput => Wait.Until(
               ExpectedConditions.ElementToBeClickable(By.Name("location")));

            public IWebElement CheckInDataPicker => Wait.Until(
               ExpectedConditions.ElementToBeClickable(By.Name("checkIn")));

            public IWebElement CheckOutDataPicker => Wait.Until(
               ExpectedConditions.ElementToBeClickable(By.Name("checkOut")));

            public IWebElement SearchBtn => Wait.Until(
               ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Search']")));

        public void IterateThroughCarousel()
        {
            //ordered list
            IWebElement orderList = Wait.Until(ExpectedConditions
               .ElementToBeClickable(By.ClassName("carousel-indicators")));

            //all list items
            IList<IWebElement> listItems = Wait.Until(ExpectedConditions
               .VisibilityOfAllElementsLocatedBy(By.XPath("//ol[@class='carousel-indicators']/li")));

            //scroll into view
            ScrollToElement(orderList);

            //iterate through each list item and print the text
            foreach (IWebElement item in listItems)
            {    
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", item);

                IWebElement activeTitle = Wait.Until(ExpectedConditions
                .ElementToBeClickable(By.XPath("//div[@class='carousel-item row active']//h3[@class='title1Light']")));

                Console.WriteLine($"Active slide title: {activeTitle.Text}");
            }
        }

        public void OpenPromotion(string promotionTitle)
        {
            //ordered list
            IWebElement orderList = Wait.Until(ExpectedConditions
               .ElementToBeClickable(By.ClassName("carousel-indicators")));

            //all list items
            IList<IWebElement> listItems = Wait.Until(ExpectedConditions
               .VisibilityOfAllElementsLocatedBy(By.XPath("//ol[@class='carousel-indicators']/li")));

            //scroll into view
            ScrollToElement(orderList);

            //iterate through list items and search for matching title
            foreach (IWebElement item in listItems)
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", item);

                IWebElement activeTitle = Wait.Until(ExpectedConditions
                .ElementToBeClickable(By.XPath("//div[@class='carousel-item row active']//h3[@class='title1Light']")));
                
                if (activeTitle.Text.Equals(promotionTitle, StringComparison.OrdinalIgnoreCase)) 
                {
                    string actionBtnXpath = $"//h3[contains(text(), '{promotionTitle}')]/following-sibling::div/a";
                    IWebElement actionBtn = Wait.Until(ExpectedConditions
                    .ElementToBeClickable(By.XPath(actionBtnXpath)));

                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", actionBtn);
                    break;
                }               
            }
        }
    }
}