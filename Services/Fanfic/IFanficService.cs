using Fanfix.Models;

namespace Fanfix.Services.Fanfics;

public interface IFanficService
{
    Task<int> CreateFanfic(Fanfic Fanfic);
    Task<Fanfic> GetFanficByID(int ID);
}