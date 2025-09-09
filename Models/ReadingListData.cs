namespace Fanfix.Models;

public class ReadingListData
{
    public string Title { get; set; }
    public DateTime LastUpdated { get; set; }

    public ICollection<FanficData> Fanfics { get; set; } = [];
}