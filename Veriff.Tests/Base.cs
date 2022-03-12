using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Veriff.Tests;

public class BaseTest
{
    public readonly ExtentReports extent;
    public ExtentTest test;

    public BaseTest()
    {
        extent = new ExtentReports();
    }

    [OneTimeSetUp]
    public virtual void BeforeAll()
    {
        // Set current directory to WORKSPACE_ROOT instead of /bin/Debug folder
        Directory.SetCurrentDirectory("../../../../");
        var htmlReporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + "/index.html");
        extent.AttachReporter(htmlReporter);
    }

    [SetUp]
    public virtual void BeforeEach()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public virtual void AfterEach()
    {
        var outcome = TestContext.CurrentContext.Result.Outcome;
        var message = TestContext.CurrentContext.Result.Message;
        RecordTestOutcomeToExtent(test, outcome, message);
        extent.Flush();
    }

    public void RecordTestOutcomeToExtent(ExtentTest test, ResultState outcome, string message)
    {
        if (outcome == ResultState.Success)
        {
            test.Pass("Test passed");
        }
        else if (outcome == ResultState.Failure)
        {
            test.Fail(message);
        }
        else if (outcome == ResultState.Error)
        {
            test.Error(message);
        }
        else if (outcome == ResultState.Inconclusive)
        {
            test.Skip(message);
        }
        else
        {
            test.Warning(message);
        }
    }
}

public class BaseUITest : BaseTest
{
    public IWebDriver driver;
    public VeriffUI veriff;

    [SetUp]
    public override void BeforeEach()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        veriff = new VeriffUI(driver).Visit();
    }

    [TearDown]
    public override void AfterEach()
    {
        var outcome = TestContext.CurrentContext.Result.Outcome;
        var message = TestContext.CurrentContext.Result.Message;
        RecordTestOutcomeToExtent(test, outcome, message);

        driver.Quit();
        extent.Flush();
    }
}

public class BaseApiTest : BaseTest
{
    public readonly Api api;

    public BaseApiTest()
    {
        api = new Api();
    }
}
