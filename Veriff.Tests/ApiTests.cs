using System.Net;
using NUnit.Framework;

namespace Veriff.Tests;

public class ApiTests : BaseApiTest
{
    [Test, Category("API")]
    public void Create_Session()
    {
        var response = api.CreateSession("Carlos Kidman", "en", "US", "PASSPORT");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data.IntegrationUrl, Is.Not.Null);
        Assert.That(response.Data.Token, Is.Not.Null);
    }

    [Test, Category("API")]
    public void Get_Session_Config()
    {
        var session = api.CreateSession("张 Zhāng", "ch", "CH", "ID_CARD").Data;
        var response = api.GetSessionConfig(session.Token);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data.Id, Is.Not.Null);
        Assert.That(response.Data.Status, Is.EqualTo("created"));
    }
}
