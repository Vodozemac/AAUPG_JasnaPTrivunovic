Feature: GuestsAndRoomsFeature

This feature covers dealing with Date Picker in CheckIn/CheckOut fields
And user interaction with Room and Guests section of the page

# Date should be in mm/dd/yyyy format
# Check out date is max 30 nights from CheckIn date
Scenario: Interaction with a date picker in fields "Check-in date" and "Check-out date"
    Given User is successfuly logged in
    When User enters 'Arundel' in Destination field
        And User sets Check In date to be '08/25/2024'
        And User sets Check Out date to be '09/12/2024'
        And clicks on Search button
    Then search results for 'Arundel' are displayed
        And search results are shown for requested dates
 
# (Ex. 2 adults, 3 children, 2 rooms)
# Allowed values for Adults are 1/2/3
# Allowed values for Children are 0/1/2
Scenario: Interaction with a number of persons and rooms
    Given User is successfuly logged in
    When User enters 'Arundel' in Destination field
        And User sets Rooms and Guests 
          | RoomNumber | Adults | Children |
          | 1          | 2      | 2        |
          | 2          | 1      | 1        |
    Then search results for 'Arundel' are displayed
        And search results are shown for requested persons