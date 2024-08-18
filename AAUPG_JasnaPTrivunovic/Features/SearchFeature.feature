Feature: SearchFeature

This feature will cover Search functionality
When user enters Destination
Than Search result should show apropriate findings

When user open a promotion shown in carusel
He is redirected to appropriate page to see details

Scenario: Login and perform a search by Destination
Given User is successfuly logged in
When User enters 'Arundel' in Destination field
	And clicks on Search button
Then search results for 'Arundel' are displayed

#Substitute scenario since there is not Pagination on the website
Scenario: User is able to iterate through carussel content and open promotion details
Given User is successfuly logged in
Then User is able to iterate through carussel content
	And Choose promotion 'New Hotels'
	And User is redirected to 'new-hotels' web page