using System.Text.Json.Serialization;

namespace LiveTrains.Models.ReferenceData;

public class Station
{
    public string Crs { get; set; }
    
    [JsonPropertyName("Value")]
    public string Name { get; set; }
}