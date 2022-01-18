Feature: AmazonHomePage
	Navigate to amazon.co.uk website

@mytag
Scenario: Navigate to amazon homepage
	Given I open the web application
	When I Get the page title
	Then It should contain "Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more"

Scenario: Verify that the page is correct and opened
	Given I am on amazon homepage
	When I check for amazon logo
	Then I should see the correct amazon logo with the right page layout

Scenario: Search for Harry Potter and the Cursed Child in section books
		Given I am on amazon homepage
		When I search for Harry Potter and the Cursed Child in section books
		Then I should see the result for Harry Potter and the Cursed Child
		And It has a badge “Best Seller”
	    And Selected type is Paperback
		And the price is £4.00


Scenario: Navigate to the book details
		Given I should see the result for Harry Potter and the Cursed Child
		When I select the first result
		Then I should be taken to the book details
		And  I should see the correct title
		And I should see the correct badge
        And I should see the correct price
		And I should see that type is Paperback 



Scenario: Add the book to the basket
		Given I am already on the book details page
		When I add the book to the basket 
		Then I should see a notification that the book has been added to the basket
		And I should see the title Added to basket 
		And I should also see that there is one item in the basket


Scenario: Click on edit the basket
		Given I have selected the basket
		When I am on edit basket page
		Then I should see the book on the list 
		And I should see the title, 
		And I should see the type of print is Paperback
		And I should see price is £4.00,
		And I should see that the quantity is 1, 
		And I should also see that the total price is £4.00





