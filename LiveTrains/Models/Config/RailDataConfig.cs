using System.Text.Json.Serialization;

namespace LiveTrains.Models.Config;

public class RailDataConfig
{
    public RailDataApiConfig LADB { get; set; } = null!;
    public RailDataApiConfig ReferenceData { get; set; } = null!;
}