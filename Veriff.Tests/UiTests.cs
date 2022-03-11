using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Veriff.Tests;

public class UiTests
{
    IWebDriver driver;
    VeriffUI veriff;

    [SetUp]
    public void BeforeEach()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        veriff = new VeriffUI(driver).Visit();
    }

    [TearDown]
    public void AfterEach()
    {
        driver.Quit();
    }

    [Test]
    public void Veriff_Me_with_Valid_Flow()
    {
        var launchVia = "Redirect";
        veriff.LaunchVeriffWith("张 Zhāng", "Chinese", "China", "Passport", launchVia);
        var qr = veriff.FindQRCode(launchVia);
        Assert.That(qr.Displayed, Is.True);
    }

    [Test]
    public void Veriff_with_Missing_Values()
    {
        // Veriff seems to work even if there are errors or missing data and defaults to English.
        // This is a bug! What should we show the user instead?
        veriff.LaunchVeriff();
        Assert.That(veriff.FindQRCode("incontext").Displayed, Is.False, "QR code is found instead of an error");
    }
}
