namespace Fanfix.Models;

public class ReadingListFanfic
{
    public int ID { get; set; }
    public int FanficID { get; set; }
    public int ReadingListID { get; set; }
    
    public Fanfic Fanfic { get; set; }
    public ReadingList ReadingList { get; set; }
}