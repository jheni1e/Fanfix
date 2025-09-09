using Fanfix.Models;

namespace Fanfix.Services.Fanfics;

public interface IFanficService
{
    Task<int> CreateFanfic(Fanfic fanfic);
    Task<Fanfic> GetFanficByID(int ID);
}