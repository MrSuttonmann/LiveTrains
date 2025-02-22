using System.Text.Json.Serialization;

namespace LiveTrains.Models.ReferenceData;

public class StationList
{
    public string Version { get; set; }
    
    [JsonPropertyName("StationList")]
    public List<Station> Stations { get; set; }
}