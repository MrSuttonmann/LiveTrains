using LiveTrains.Models;
using LiveTrains.Models.Config;
using LiveTrains.Models.ReferenceData;
using Microsoft.Extensions.Options;

namespace LiveTrains.Services;

public class RailDataService(HttpClient httpClient, IOptions<RailDataConfig> railDataConfig)
{
    private readonly RailDataConfig _config = railDataConfig.Value;
    
    public async Task<DepartureBoard> GetDepartureBoardAsync(string crs)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_config.LADB.ApiUrl}/GetDepartureBoard/{crs}");
        request.Headers.Add("X-ApiKey", _config.LADB.ApiKey);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var departureBoard = await response.Content.ReadFromJsonAsync<DepartureBoard>();
        return departureBoard!;
    }

    public async Task<StationList> GetStationListAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_config.ReferenceData.ApiUrl}/GetStationList/1");
        request.Headers.Add("X-ApiKey", _config.ReferenceData.ApiKey);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var stationList = await response.Content.ReadFromJsonAsync<StationList>();
        return stationList!;
    }
}