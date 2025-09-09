using Fanfix.Models;
using Fanfix.Services.Fanfics;
using Fanfix.Services.Users;

namespace Fanfix.UseCases.DeleteFanfic;

public class DeleteFanficUseCase
(
    IFanficService fanficService,
    IUserService userService,
    FanfixDbContext ctx
)
{
    public async Task<Result<DeleteFanficResponse>> Do(DeleteFanficPayload payload)
    {
        var fanfic = await fanficService.GetFanficByID(payload.FanficID);
        if (fanfic is null)
            return Result<DeleteFanficResponse>.Fail("Fanfic not found.");

        var creator = await userService.GetUserByID(payload.CreatorID);
        if (creator is null)
            return Result<DeleteFanficResponse>.Fail("Creator not found.");

        if (creator != fanfic.Creator || payload.CreatorID != creator.ID)
            return Result<DeleteFanficResponse>.Fail("Error fetching creator/fanfic details.");

        ctx.Fanfics.Remove(fanfic);
        await ctx.SaveChangesAsync();

        return Result<DeleteFanficResponse>.Success(new());
    }
}