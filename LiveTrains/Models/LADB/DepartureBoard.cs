using System.Text.Json.Serialization;

namespace LiveTrains.Models.LADB;

public class DepartureBoard
{
    [JsonPropertyName("locationName")]
    public string? StationName { get; set; }
    [JsonPropertyName("crs")]
    public string? StationCode { get; set; }
    [JsonPropertyName("trainServices")]
    public TrainService[]? TrainServices { get; set; }
    
    [JsonPropertyName("nrccMessages")]
    public StationMessage[]? StationMessages { get; set; }
    
    public DateTime GeneratedAt { get; set; }
}