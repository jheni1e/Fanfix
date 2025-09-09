namespace Fanfix.Models;

public class Fanfic
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public int CreatorID { get; set; }
    public User Creator { get; set; }

    public ICollection<ReadingList> ReadingLists { get; set; } = [];
}