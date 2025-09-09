using Fanfix.Models;
using Fanfix.Services.Fanfics;
using Fanfix.Services.Users;

namespace Fanfix.UseCases.EditList;

public class EditListUseCase
(
    IFanficService fanficService,
    IUserService userService,
    FanfixDbContext ctx
)
{
    public async Task<Result<EditListResponse>> Do(EditListPayload payload)
    {
        var list = await ctx.ReadingLists.FindAsync(payload.ReadingListID);
        if (list is null)
            return Result<EditListResponse>.Fail("Reading List not found.");

        var fanfic = await fanficService.GetFanficByID(payload.FanficID);
        if (fanfic is null)
            return Result<EditListResponse>.Fail("Fanfic not found.");

        var creator = await userService.GetUserByID(payload.CreatorID);
        if (creator is null)
            return Result<EditListResponse>.Fail("Creator not found.");

        list.Fanfics.Add(fanfic);
        await ctx.SaveChangesAsync();

        return Result<EditListResponse>.Success(new());
    }
}