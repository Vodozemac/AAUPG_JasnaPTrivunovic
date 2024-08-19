using AAUPG_JasnaPTrivunovic.POMs;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AAUPG_JasnaPTrivunovic.Steps
{
    [Binding]
    public class RoomAndGuestsSteps
    {
        public SignInPage SignInPage;
        public SearchPage SearchPage;
        public RoomAndGuestsPage RoomAndGuestsPage;
        private readonly ScenarioContext _scenarioContext;

        public RoomAndGuestsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            SignInPage = new SignInPage();
            SearchPage = new SearchPage();
            RoomAndGuestsPage = new RoomAndGuestsPage();
        }

        [When(@"User sets Check In date to be '([^']*)'")]
        public void WhenUserSetsCheckInDateToBe(string checkInDate)
        {
            RoomAndGuestsPage.CheckInDatePicker.Click();
            RoomAndGuestsPage.SelectDateFromDatePicker(checkInDate);
            _scenarioContext["CheckInDate"] = checkInDate;
        }

        [When(@"User sets Check Out date to be '([^']*)'")]
        public void WhenUserSetsCheckOutDateToBe(string checkOutDate)
        {
            RoomAndGuestsPage.CheckOutDatePicker.Click();
            RoomAndGuestsPage.SelectDateFromDatePicker(checkOutDate);
            _scenarioContext["CheckOutDate"] = checkOutDate;
        }

        [Then(@"search results are shown for requested dates")]
        public void ThenSearchResultsAreShownForRequestedDates()
        {
            var requestedCheckInDate = _scenarioContext["CheckInDate"];
            var requestedCheckOutDate = _scenarioContext["CheckOutDate"];

            var actualCheckInDate = RoomAndGuestsPage.getDatePickerValue(RoomAndGuestsPage.ActualCheckInDate);
            var actualCheckOutDate = RoomAndGuestsPage.getDatePickerValue(RoomAndGuestsPage.ActualCheckOutDate);

            Assert.AreEqual(requestedCheckInDate, actualCheckInDate);
            Assert.AreEqual(requestedCheckOutDate, actualCheckOutDate);
        }

        [When(@"User sets Rooms and Guests")]
        public void WhenUserSetsRoomsAndGuests(Table table)
        {
            _scenarioContext["TotalPersonsCount"] = RoomAndGuestsPage.PopulateRoomsAndGuests(table);
            _scenarioContext["TotalRoomsCount"] = table.RowCount;
        }

        [Then(@"search results are shown for requested persons")]
        public void ThenSearchResultsAreShownForRequestedPersons()
        {
            var actualRoomAndGuests = RoomAndGuestsPage.ActualRoomsAndGuests.GetAttribute("value");
            var expectedRoomAndGuests = $"{_scenarioContext["TotalRoomsCount"]} rooms, {_scenarioContext["TotalPersonsCount"]} guests";
            Assert.AreEqual(expectedRoomAndGuests, actualRoomAndGuests);
        }

    }
}