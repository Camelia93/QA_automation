Feature: Login functionality
  To verify the login page works correctly
  As a registered user
  I want to be able to log in with valid credentials

  @smoke
  Scenario: Successful login with valid credentials
    Given I open the login page
    When I enter "student" as username and "Password123" as password
    And I click the login button
    Then I should be redirected to the success page
    And I should see the "Log out" button

  @smoke
  Scenario: Login fails with invalid credentials
    Given I open the login page
    When I enter "student" as username and "Password12" as password
    And I click the login button
    Then I should see an error message "Your username is invalid"
