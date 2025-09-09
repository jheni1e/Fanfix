using Fanfix.Models;
using Fanfix.Services.Fanfics;

namespace Fanfix.UseCases.DeleteFanfic;

public class DeleteFanficUseCase
(
    IFanficService service,
    FanfixDbContext ctx
)
{
    public async Task<Result<DeleteFanficResponse>> Do(DeleteFanficPayload payload)
    {
        var fanfic = await service.GetFanficByID(payload.FanficID);
        if (fanfic is null)
            return Result<DeleteFanficResponse>.Fail("Fanfic not found.");

        ctx.Fanfics.Remove(fanfic);
        await ctx.SaveChangesAsync();

        return Result<DeleteFanficResponse>.Success(new());
    }
}