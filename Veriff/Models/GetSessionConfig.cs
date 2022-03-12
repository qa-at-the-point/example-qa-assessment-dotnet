using System.Text.Json.Serialization;

namespace Veriff.Models;

public record GetSessionConfigResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("initData")]
    public InitData InitData { get; set; }

    [JsonPropertyName("vendorIntegration")]
    public VendorIntegration VendorIntegration { get; set; }

    [JsonPropertyName("activeVerificationSession")]
    public object ActiveVerificationSession { get; set; }

    [JsonPropertyName("previousVerificationSessions")]
    public object PreviousVerificationSessions { get; set; }

    [JsonPropertyName("activeProofOfAddressSession")]
    public object ActiveProofOfAddressSession { get; set; }

    [JsonPropertyName("previousProofOfAddressSessions")]
    public object PreviousProofOfAddressSessions { get; set; }

    [JsonPropertyName("copyStrings")]
    public object CopyStrings { get; set; }
}

public record InitData
{
    [JsonPropertyName("integrationUrl")]
    public string IntegrationUrl { get; set; }

    [JsonPropertyName("sessionToken")]
    public string SessionToken { get; set; }
}

public record VendorIntegration
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("publicName")]
    public string PublicName { get; set; }

    [JsonPropertyName("callback")]
    public string Callback { get; set; }

    [JsonPropertyName("flowLayout")]
    public string FlowLayout;

    [JsonPropertyName("leaveUserWaitingTime")]
    public int? LeaveUserWaitingTime { get; set; }

    [JsonPropertyName("featureFlags")]
    public object FeatureFlags { get; set; }
}
