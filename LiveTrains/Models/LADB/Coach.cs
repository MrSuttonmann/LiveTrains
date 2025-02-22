using System.Text.Json.Serialization;

namespace LiveTrains.Models.LADB;

public class Coach
{
    [JsonPropertyName("coachClass")]
    public string? Class { get; set; }
    public string Number { get; set; } = null!;

    public CoachToilet? Toilet { get; set; }
}
