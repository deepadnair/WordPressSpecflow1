Feature:F Login
	In order to create new post
	As an Editor
	I want to be able to login to the dashboard

Scenario: Successful Login
	Given I Navigate to the Login page
	When I Login with Username 'admin' and Password 'password' on the Login Page		
	Then the User Name 'admin' Should be seen on the Dashboard Page 

Scenario Outline: UnSuccessful Login 
	Given I Navigate to the Login page
	When I Unsucessfully Login with Username '<username>' and Password '<password>' on the Login Page
	Then I Should See Error Message '<errorMsg>' on the Login Page

Examples: 
 | name             | username | password | errorMsg                                                                                 |
 | Blank Username   |          | password | ERROR: The username field is empty.                                                      |
 | Blank Password   | admin    |          | ERROR: The password field is empty.                                                      |
 | invalid Password | admin    | $%GGH    | ERROR: The password you entered for the username admin is incorrect. Lost your password? |
 | invalid username | 66987    | password | ERROR: Invalid username. Lost your password?                                             |
 