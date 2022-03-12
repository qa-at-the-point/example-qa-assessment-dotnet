using NUnit.Framework;
namespace Veriff.Tests;

public class UiTests : BaseUITest
{
    [Test, Category("UI")]
    public void Launch_Veriff_with_valid_values_succeeds()
    {
        var launchVia = "Redirect";
        veriff.LaunchVeriffWith("张 Zhāng", "中文（简体)", "China", "Passport", launchVia);
        var qr = veriff.FindQRCode(launchVia);
        Assert.That(qr.Displayed, Is.True);
    }

    [Test, Category("UI")]
    public void Launch_veriff_with_missing_values_should_raise_error()
    {
        // Veriff seems to work even if there are errors or missing data and defaults to English.
        // This is a bug! What should we show the user instead?
        veriff.LaunchVeriff();
        Assert.That(veriff.FindQRCode("incontext").Displayed, Is.False, "QR code is found instead of an error");
    }
}
