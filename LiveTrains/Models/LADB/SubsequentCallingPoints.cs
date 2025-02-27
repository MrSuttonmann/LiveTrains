using System.Text.Json.Serialization;

namespace LiveTrains.Models.LADB
{
    public class SubsequentCallingPoints
    {
        [JsonPropertyName("callingPoint")]
        public CallingPoint[]? CallingPoints { get; set; }
    }
}
