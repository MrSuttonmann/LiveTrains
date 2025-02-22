using LiveTrains.Models.ReferenceData;

namespace LiveTrains.Services;

public class StationListService(RailDataService railDataService)
{
    private StationList? _stationList;
    
    public async Task<List<Station>> SearchStationsAsync(string search)
    {
        var stationList = await GetStationListAsync();
        return stationList.Stations
            .Where(s => s.Name.StartsWith(search, StringComparison.OrdinalIgnoreCase))
            .OrderBy(s => s.Name)
            .ToList();
    }
    
    public async Task<StationList> GetStationListAsync()
    {
        var versionDate = DateTime.Now.ToString("yyyy-MM-dd");

        if (_stationList is null || !_stationList.Version.StartsWith(versionDate))
        {
            _stationList = await railDataService.GetStationListAsync();
        }

        return _stationList;
    }
}