using LiveTrains.Models;
using LiveTrains.Models.Config;
using LiveTrains.Models.ReferenceData;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace LiveTrains.Services;

public partial class RailDataService(HttpClient httpClient, IOptions<RailDataConfig> railDataConfig)
{
    private readonly RailDataConfig _config = railDataConfig.Value;

    [GeneratedRegex("^[A-Z]{3}$")]
    private static partial Regex CrsRegex();

    public async Task<DepartureBoard> GetDepartureBoardAsync(string crs)
    {
        if(!CrsRegex().IsMatch(crs))
        {
            throw new ArgumentOutOfRangeException(nameof(crs));
        }

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_config.LADB.ApiUrl}/GetDepartureBoard/{crs}");
        request.Headers.Add("X-ApiKey", _config.LADB.ApiKey);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var departureBoard = await response.Content.ReadFromJsonAsync<DepartureBoard>();
        return departureBoard!;
    }

    public async Task<DepartureBoard> GetDepartureBoardWithDetailsAsync(string crs)
    {
        if (!CrsRegex().IsMatch(crs))
        {
            throw new ArgumentOutOfRangeException(nameof(crs));
        }

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_config.LADB.ApiUrl}/GetDepBoardWithDetails/{crs}");
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