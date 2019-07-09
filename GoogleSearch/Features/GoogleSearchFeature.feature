Feature: GoogleSearchTest
	Check the results of searching phrase 'predica'
	on the website 'google.pl'

Scenario: Search for phrase and check company address
	Given I have entered 'predica' into the search textbox
	When I press search button
	Then the result should be 'ul. Altowa 2, Warsaw' on the location textbox

Scenario: Search for phrase and check first result
	Given I have entered 'predica' into the search textbox
	When I press search button
	Then the result should be 'https://predica.pl/' as a first result

Scenario: Search for phrase and check if top 5 results contains linkedin and facebook
	Given I have entered 'predica' into the search textbox
	When I press search button
	Then the result should be 'https://pl.linkedin.com/company/predica-business-solutions' and 'https://pl-pl.facebook.com/predicabusinesssolutions' in top 5 results of searching