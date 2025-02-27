using System.Text.Json.Serialization;

namespace LiveTrains.Models.LADB;

public class CallingPoint
{
    [JsonPropertyName("crs")] public string Code { get; set; } = null!;

    public string LocationName { get; set; } = null!;

    [JsonPropertyName("st")] public string ScheduledTime { get; set; } = null!;
    [JsonPropertyName("et")] public string EstimatedTime { get; set; } = null!;
}
