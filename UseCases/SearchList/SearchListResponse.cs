using Fanfix.Models;

namespace Fanfix.UseCases.SearchList;

public record SearchListResponse (
    string Title,
    DateTime LastUpdated,
    IEnumerable<FanficData> FanficList
);