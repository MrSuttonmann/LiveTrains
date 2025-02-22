using System.Text.Json.Serialization;

namespace LiveTrains.Models;

public class TrainServiceLocation
{
    public string LocationName { get; set; } = null!;
    [JsonPropertyName("crs")]
    public string LocationCode { get; set; } = null!;
    [JsonPropertyName("assocIsCancelled")]
    public bool AssociatedIsCancelled { get; set; }
}