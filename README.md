# Software Development Technologies Home Task

This repository contains automated tests for a Job Management System using NUnit and Selenium WebDriver. The tests cover the following scenarios:

1. Adding a new job: Student or Intern.
2. Verifying that the changes are visible on the Job Title page.
3. Deleting a selected job.

## Dependencies

The following NuGet packages are used in this project:

- `coverlet.collector/3.2.0`
- `Microsoft.NET.Test.Sdk/17.5.0`
- `NUnit.Analyzers/3.6.1`
- `NUnit/3.13.3`
- `NUnit3TestAdapter/4.4.2`
- `Selenium.WebDriver/4.9.1`

## Setup

1. Clone this repository to your local machine.
2. Restore the NuGet packages using Visual Studio or the following command:
```
dotnet restore
```
3. Download and install the appropriate WebDriver for your browser (e.g., ChromeDriver for Chrome).

## Running Tests

You can run the tests using the following command:

```
dotnet test
```

## Test Steps

1. Add new job: Student or Intern:
   - Open the application and navigate to the Admin section.
   - Go to Job - Job Titles.
   - Click on the "Add" button.
   - Enter the job title.
   - Add the job description (up to 20 characters).
   - Add a note.
   - Save the changes.

2. Verify the changes on the Job Title page:
   - Navigate to the Job Title page.
   - Check that the changes made in the previous step are visible.

3. Delete a selected job:
   - Select the desired job from the list.
   - Click the "Delete Selected" button.
   - Ensure that the selected job is removed.
