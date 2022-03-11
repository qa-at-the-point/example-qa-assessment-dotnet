using System.Text.Json.Serialization;

namespace Veriff.Models;

public record CreateSessionPayload
{
    [JsonPropertyName("full_name")]
    public string FullName { get; set; }

    [JsonPropertyName("lang")]
    public string Language { get; set; }

    [JsonPropertyName("document_country")]
    public string DocumentCountry { get; set; }

    [JsonPropertyName("document_type")]
    public string DocumentType { get; set; }

    [JsonPropertyName("additionalData")]
    public object AdditionalData { get; set; }
}

public record CreateSessionResponse
{
    [JsonPropertyName("integrationUrl")]
    public string IntegrationUrl { get; set; }

    [JsonPropertyName("sessionToken")]
    public string Token { get; set; }
}
