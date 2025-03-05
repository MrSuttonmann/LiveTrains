using System.Text.Json.Serialization;

namespace LiveTrains.Models.LADB;

public class TrainService
{
    [JsonPropertyName("serviceID")]
    public string ServiceId { get; set; } = null!;
    public string? Operator { get; set; }
    public string? Platform { get; set; }
    public string Etd { get; set; } = null!;
    public string Std { get; set; } = null!;
    
    [JsonPropertyName("futureDelay")]
    public bool Delayed { get; set; }
    
    public string? DelayReason { get; set; }
    
    [JsonPropertyName("isCancelled")]
    public bool Cancelled { get; set; }
    public TrainServiceLocation[]? Origin { get; set; }
    public TrainServiceLocation[]? Destination { get; set; }

    public Formation? Formation { get; set; }

    [JsonPropertyName("subsequentCallingPoints")]
    public SubsequentCallingPoints[]? CallingPoints { get; set; }
}