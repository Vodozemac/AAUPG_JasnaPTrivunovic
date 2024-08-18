Feature: LoginFeature

In order to test if sign in works
As a user
I want to be able to access the system after I enter my credencials

Scenario: Login with valid credentials
Given User navigates to Travelodge website
When user clicks on Login button
	And login form is displayed
	And user enters valid email and password
Then user is successfuly signed in

Scenario: Login with invalid credentials
Given User navigates to Travelodge website
When user clicks on Login button
	And login form is displayed
	And user enters invalid email and password
Then error message is displayed