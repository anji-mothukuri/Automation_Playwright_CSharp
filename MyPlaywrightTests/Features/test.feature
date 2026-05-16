Feature: Launch Chrome
  In order to verify Playwright works
  As a tester
  I want to launch the browser and open a webpage

  Scenario: Successfully launch Chrome and open Google
    Given I launch the Chrome browser
    When I navigate to "https://google.com"
    Then I should see the page title contains "Google"
    And I close the browser
