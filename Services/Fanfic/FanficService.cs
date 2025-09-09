using Fanfix.Models;
using Microsoft.EntityFrameworkCore;

namespace Fanfix.Services.Fanfics;

public class FanficService(FanfixDbContext ctx) : IFanficService
{
    public async Task<int> CreateFanfic(Fanfic fanfic)
    {
        ctx.Fanfics.Add(fanfic);
        await ctx.SaveChangesAsync();
        return fanfic.ID;
    }

    public async Task<Fanfic> GetFanficByID(int ID)
    {
        return await ctx.Fanfics.FirstOrDefaultAsync(
            f => f.ID == ID
        );
    }
}