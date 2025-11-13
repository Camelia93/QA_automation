Feature: API Testing
  To verify backend functionality
  As a QA Engineer
  I want to test REST API responses for a public service

  @api
  Scenario: Get user details from a public API
    Given I have the API endpoint "https://reqres.in/api/users/2"
    When I send a GET request
    Then the response status should be 200
    And the response should contain the user email "janet.weaver@reqres.in"
    