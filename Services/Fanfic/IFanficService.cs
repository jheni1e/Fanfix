namespace Fanfix.Services.Fanfic;

public interface IFanficService
{
    Task<int> CreateFanfic(Fanfic fanfic);
    Task<Fanfic> GetFanfic(string Username);
    Task<Fanfic> GetFanficByID(int ID);
}