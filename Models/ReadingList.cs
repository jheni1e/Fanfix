namespace Fanfix.Models;

public class ReadingList
{
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime LastUpdated { get; set; }

    public ICollection<Fanfic> Fanfics { get; set; } = [];
}