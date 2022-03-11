using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Veriff;

public class VeriffUI
{
    readonly IWebDriver _driver;
    readonly WebDriverWait _wait;

    public VeriffUI(IWebDriver driver, int timeout = 10)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
    }

    public VeriffUI Visit()
    {
        _driver.Url = "https://demo.saas-3.veriff.me/";
        return this;
    }

    public IWebElement EnterFullName(string fullName)
    {
        var fullNameField = _wait.Until(d => d.FindElement(By.CssSelector("[name='name']")));
        fullNameField.Clear();
        fullNameField.SendKeys(fullName);
        return fullNameField;
    }

    public IWebElement SelectLanguage(string language)
    {
        // The dropdown is actually a button element that opens a list under script elements.
        // Poor UI design and not accessible. RAISE AS ISSUE!
        var dropdown = _wait.Until(d => d.FindElement(By.CssSelector("[name='language']")));
        dropdown.Click();
        var languageOptions = _driver.FindElements(By.CssSelector("ul[id='downshift-0-menu'] > li"));

        foreach (var option in languageOptions)
        {
            if (option.Text == language)
            {
                option.Click();
                break;
            }
        }
        return dropdown;
    }

    public IWebElement SelectCountry(string country)
    {
        var countryField = _driver.FindElement(By.CssSelector("[name='documentCountry']"));
        countryField.SendKeys(country);
        var countryOptions = _driver.FindElements(By.CssSelector("ul[id='downshift-1-menu'] > li"));
        countryOptions[0].Click();
        return countryField;
    }

    public IWebElement SelectDocumentType(string docType)
    {
        var dropdown = _driver.FindElement(By.CssSelector("[name='documentType']"));
        dropdown.Click();
        var documentOptions = _driver.FindElements(By.CssSelector("ul[id='downshift-2-menu'] > li"));
        foreach (var option in documentOptions)
        {
            if (option.Text == docType)
            {
                option.Click();
                break;
            }
        }
        return dropdown;
    }

    public IWebElement SelectLaunchVia(string launchVia)
    {
        var launch = launchVia.ToLower();
        if (new string[] { "incontext", "redirect" }.Contains(launch))
        {
            var button = _driver.FindElement(By.CssSelector($"[value='{launch}']"));
            button.Click();
            return button;
        }
        else
        {
            throw new Exception($"Invalid launchVia. Must be 'incontext' or 'redirect'");
        }
    }

    public VeriffUI LaunchVeriff()
    {
        _wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']"))).Click();
        return this;
    }

    public VeriffUI LaunchVeriffWith(string fullName, string language, string country, string docType, string launchVia)
    {
        EnterFullName(fullName);
        SelectLanguage(language);
        SelectCountry(country);
        SelectDocumentType(docType);
        SelectLaunchVia(launchVia);
        return LaunchVeriff();
    }

    public IWebElement FindQRCode(string launchVia)
    {
        if (launchVia.ToLower() == "incontext")
        {
            _wait.Until(d => d.FindElement(By.CssSelector("#veriffFrame")));
            _driver.SwitchTo().Frame("veriffFrame");
        }
        return _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'QR')]")));
    }
}
