
# Automation QA Assigment

This repository provides automated UI tests for Travelodge application using Selenium WebDriver and C#. The tests are structured to ensure that all requested test cases in Assigment are covered.

Link to the web site: https://www.travelodge.co.uk/


##  Project Structure

The project is organized into three main sections:

#### Features
Contains the feature files that define all test scenarios.

Files:
1. LoginFeature.feature — Scenarios related to the login functionality.
2. GuestsAndRoomsFeature.feature — Scenarios for managing guests and rooms.
3. SearchFeature.feature — Scenarios for search functionality.

#### Steps
Contains the step definitions that implement the steps described in the feature files.


#### POM (Page Object Model)
Contains the Page Object Model (POM) classes that represent the structure and behavior of the application's web pages.
## Setup and Configuration

#### 1. Clone the Repository:

clone:  https://github.com/Vodozemac/AAUPG_JasnaPTrivunovic

#### 2. Install Dependencies:

- Ensure you have the .NET SDK (.NET 7 is used) installed.
- Restore NuGet packages
- Rebuild the project

#### 3. Configure WebDriver:

Make sure the Chreome WebDriver executable is installed and configured in your local environment.

Chrome driver version being used: Version 127.0.6533.120 (Official Build) (64-bit)

#### 4. Add Speckflow extension
In order to have all Specflow bindings working, download Specflow extension in VisualStudio

#### 5. Enable Test Explorer in VisualStudio
Execute tests
