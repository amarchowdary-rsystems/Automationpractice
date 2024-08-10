
# Project Title

## Overview
This project is a test automation suite built using .NET 8.0 and Playwright. It is designed to automate the user management functionalities within a web application. The primary focus is on adding, editing, and deleting team members through a series of Playwright-based tests integrated with NUnit.

## Features
- Automated login and navigation to the "Manage Team Members" page.
- Adding a new team member with multiple data sets.
- Editing existing team member details.
- Deleting a team member and verifying the deletion.
- Handling alerts and success messages within the application.

## Technologies Used
- **.NET 8.0**: The core framework used for building the test suite.
- **Playwright**: Used for automating browser interactions.
- **NUnit**: The testing framework used to define and execute the tests.
- **CsvHelper**: For handling CSV data.
- **coverlet.collector**: For collecting code coverage data.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (if Playwright needs to install browser dependencies)
- A compatible IDE or text editor like Visual Studio or Visual Studio Code.

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/amarchowdary-rsystems/Automationpractice.git
   ```
2. Navigate to the project directory:
   ```bash
   cd Automationpractice
   ```
3. Restore the project dependencies:
   ```bash
   dotnet restore
   ```

## Configuration
- **Test Data**: The test data is managed through a `credentials.csv` file, which is copied to the output directory during the build process.
- **Locators**: The web elements are identified using locators defined in a separate class.

## Usage
- To run the tests:
  ```bash
  dotnet test
  ```
- The tests can be executed individually or as a complete suite. For example, to run a specific test:
  ```bash
  dotnet test --filter "Name~AddNewTeamMember"
  ```

## Running Tests
- The test suite includes the following key tests:
  - `AddNewTeamMember`: Adds a new team member using various data sets and verifies the result based on expected outcomes.
  - `EditUserData`: Edits the details of an existing team member and verifies the changes.
  - `DeleteUserData`: Deletes a team member and ensures the deletion is successful.

Drop Down : Role
Value	Text
372074	Parent/Home Caregiver
372075	Paraprofessional/1:1 Aide
372076	Related Service Provider
372077	Teacher
372078	Administrator
372079	Lead Teacher/Administrator
372082	Case Manager/Lead Teacher
403674	Prod Custom Role
437428	TC
450958	TCResource
479161	ParentRole
613531	Adding new one
672732	T4
674176	SCRtest
676388	RDT-12939
706933	t1
758364	t2
798658	wdw
842868	TEST ABC setting showUp
847530	fwfwdw
877753	TestROle
940821	Parent Custom Role
948691	PermissionTest
1145803	gdrghdrgdrg
1192336	TEST role 06/11



Drop Down: Teacher
1	General Education
2	Special Education
3	General Education & Special Education