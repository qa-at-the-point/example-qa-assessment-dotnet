using RestSharp;
using Veriff.Models;

namespace Veriff;
public class Api
{
    public readonly RestClient client;

    public Api()
    {
        client = new RestClient();
    }

    public RestResponse<CreateSessionResponse> CreateSession(string fullName, string language, string country, string docType)
    {
        var payload = new CreateSessionPayload()
        {
            FullName = fullName,
            Language = language,
            DocumentCountry = country,
            DocumentType = docType,
            AdditionalData = new { IsTest = false }
        };

        var request = new RestRequest("https://demo.saas-3.veriff.me/", Method.Post).AddBody(payload);
        var response = client.ExecuteAsync<CreateSessionResponse>(request).Result;
        return response;
    }

    public RestResponse<GetSessionConfigResponse> GetSessionConfig(string token)
    {
        var request = new RestRequest(
            "https://magic.saas-3.veriff.me/api/v2/sessions", Method.Get)
            .AddHeader("Authorization", $"Bearer {token}"
        );
        var response = client.ExecuteAsync<GetSessionConfigResponse>(request).Result;
        return response;
    }
}
