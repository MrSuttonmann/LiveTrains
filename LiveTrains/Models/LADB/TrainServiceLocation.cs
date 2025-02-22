using System.Text.Json.Serialization;

namespace LiveTrains.Models;

public class TrainServiceLocation
{
    public string LocationName { get; set; }
    [JsonPropertyName("crs")]
    public string LocationCode { get; set; }
    [JsonPropertyName("assocIsCancelled")]
    public bool AssociatedIsCancelled { get; set; }
}