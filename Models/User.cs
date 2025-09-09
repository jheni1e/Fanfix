namespace Fanfix.Models;

public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public DateTime AccCreatedAt { get; set; }

    public ICollection<Fanfic> Fanfics { get; set; } = [];
    public ICollection<ReadingList> ReadingLists { get; set; } = [];
}