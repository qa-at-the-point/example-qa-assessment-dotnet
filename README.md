# Example QA Assessment

A real-world technical assessment from a company hiring QA / Software Testers.

## The Quality Engineer Test Task

Find the assessment instructions in this file: [quality-engineer-test.md](./qualiti-engineer-test.md)

> Give this a try yourself before looking at the solution in this repo!

### A Solution

To look at the solution I came up with, look for these files:

- Test Plan - [veriff.feature](./veriff.feature) in a Gherkin-style format
- UI Tests - [UiTests.cs](./Veriff.Tests/UiTests.cs)
- API Tests - [ApiTests.cs](./Veriff.Tests/ApiTests.cs)
- Veriff Code abstraction (pages and api) - [Veriff Project](./Veriff/)
- Bugs found - [BUGS.md](./BUGS.md)

Besides that, my solution uses:

- `C# (dotnet core)` as my language
- `NUnit` as my test framework
- `Selenium` to automate the browser
- `RestSharp` to automate the API requests

> ⏰ I gave myself 2 hours to do this

## Setup

- 🐍 **_dotnet 6_** or higher is required

1. Clone the repo

   ```bash
   git clone https://github.com/qa-at-the-point/example-qa-assessment-dotnet.git
   ```

2. Install packages

   ```bash
   # Installs all packages and dependencies
   dotnet build
   ```

## Run Tests

However, the base command is always the same:

```bash
# Run all tests
dotnet test
```

> 💡 The terminal will show test results and summary once the Test Run is complete

## Submit a Bug or Request

If you've found an bug or you have an idea or feature request, please create an issue on the [Issues Tab](https://github.com/qa-at-the-point/example-qa-assessment/issues)
