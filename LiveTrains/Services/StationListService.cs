using LiveTrains.Models.ReferenceData;

namespace LiveTrains.Services;

public class StationListService(RailDataService railDataService)
{
    private StationList? _stationList;
    private DateTime _stationListLastUpdate = DateTime.MinValue;

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
        
        if (_stationList is null || ShouldUpdateStationList())
        {
            _stationList = await railDataService.GetStationListAsync();
            _stationListLastUpdate = DateTime.UtcNow;
        }

        return _stationList;
    }

    private bool ShouldUpdateStationList()
    {
        return DateTime.UtcNow - _stationListLastUpdate == TimeSpan.FromDays(30);
    }
}