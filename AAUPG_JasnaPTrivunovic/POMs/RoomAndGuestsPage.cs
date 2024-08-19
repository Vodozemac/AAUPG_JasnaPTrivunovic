using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using TechTalk.SpecFlow;

namespace AAUPG_JasnaPTrivunovic.POMs
{
    public class RoomAndGuestsPage : BasePage
    {
        public IWebElement CheckOutDatePicker => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.Name("checkOut")));

        public IWebElement CheckInDatePicker => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.Name("checkIn")));

        public IWebElement RoomAndGuestsDialog => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.XPath("//div[@title='Rooms & Guests']")));

        public IWebElement AddRoomBtn => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.XPath("(//button[contains(@class,'addRoom add-room-home')])[3]")));
        
        public IWebElement DoneBtn => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.XPath("(//button[text()='Done'])[3]")));

        public IWebElement ActualCheckInDate => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.Id("checkIn")));

        public IWebElement ActualCheckOutDate => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.Id("checkOut")));

        public IWebElement ActualRoomsAndGuests => Wait.Until(ExpectedConditions
            .ElementToBeClickable(By.Id("rooms-display")));

        public void SelectNumberOfPersonsInRoom(string adults, string children, int roomNumber) 
        {
            string adultsInRoomXpath = $"(//div[contains(@class,'rooms_adult')])[{roomNumber+2}]";
            IWebElement adultsDropdown = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(adultsInRoomXpath)));
            ScrollToElement(adultsDropdown);
            adultsDropdown.Click();

            string adultsNumberXpath = $"//ul[@aria-expanded='true']/li[@data-value='{adults}']";
            IWebElement adultsNumberOption = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(adultsNumberXpath)));
            adultsNumberOption.Click();

            string childrenInRoomXpath = $"(//div[contains(@class,'rooms_children')])[{roomNumber+2}]";
            IWebElement childrenDropdown = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(childrenInRoomXpath)));
            ScrollToElement(childrenDropdown);
            childrenDropdown.Click();

            string childrenNumberXpath = $"//ul[@aria-expanded='true']/li[@data-value='{children}']";
            IWebElement childrenNumberOption = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(childrenNumberXpath)));
            childrenNumberOption.Click();
        }

        public int PopulateRoomsAndGuests(Table table) 
        {
            int totalPersonsNumber = 0;
            RoomAndGuestsDialog.Click();

            int rowCount = table.Rows.Count;

            if (rowCount > 1) 
            {
                AddRoomBtn.Click();
            } 

            foreach (var row in table.Rows)
            {
                int roomNumber = int.Parse(row["RoomNumber"]);
                int adults = int.Parse(row["Adults"]);
                int children = int.Parse(row["Children"]);
                totalPersonsNumber += adults + children;

                SelectNumberOfPersonsInRoom(adults.ToString(), children.ToString(), roomNumber);
            }

            ScrollToElement(DoneBtn);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", DoneBtn);

            return totalPersonsNumber;
        }

        public void SelectDateFromDatePicker(string desiredDate)
        {
            IWebElement datePicker = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-datepicker-div")));

            DateTime date = DateTime.Parse(desiredDate);
            string desiredDay = date.Day.ToString();
            string desiredMonth = date.ToString("MMMM");
            string desiredYear = date.ToString("yyyy");

            //sel correct month and year
            while (true)
            {
                IWebElement monthLabel = datePicker.FindElement(By.ClassName("ui-datepicker-month"));
                string currentMonth = monthLabel.Text;

                IWebElement yearLabel = datePicker.FindElement(By.ClassName("ui-datepicker-year"));
                string currentYear = yearLabel.Text;

                string currentMonthYear = $"{currentMonth} {currentYear}";

                if (currentMonth == desiredMonth && currentYear == desiredYear)
                {
                    break;
                }
                else if (DateTime.Parse(currentMonthYear) < date)
                {
                    //next month
                    IWebElement nextButton = datePicker.FindElement(By.CssSelector(".ui-datepicker-next"));
                    nextButton.Click();
                }
                else
                {
                    //go back
                    IWebElement prevButton = datePicker.FindElement(By.CssSelector(".ui-datepicker-prev"));
                    prevButton.Click();
                }
            }

            //choes day
            IWebElement dayToSelect = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//td[@data-handler='selectDay']/a[text()='{desiredDay}']")));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", dayToSelect);
        }

        public string getDatePickerValue(IWebElement element) 
        {            
            string inputDate = element.GetAttribute("data-value");
            DateTime date = DateTime.ParseExact(inputDate, "dd/MM/yy", CultureInfo.InvariantCulture);
            string outputDate = date.ToString("MM/dd/yyyy");

            return outputDate;  
        }           
    }
}