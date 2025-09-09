using Fanfix.Models;
using Fanfix.Services.Fanfics;
using Fanfix.Services.Users;

namespace Fanfix.UseCases.CreateFanfic;

public class CreateFanficUseCase(
    IFanficService fanficService,
    IUserService userService
)
{
    public async Task<Result<CreateFanficResponse>> Do(CreateFanficPayload payload)
    {
        var creator = await userService.GetUserByID(payload.CreatorID);

        var fanfic = new Fanfic
        {
            Title = payload.Title,
            Text = payload.Text,
            CreatorID = payload.CreatorID,
            Creator = creator
        };

        await fanficService.CreateFanfic(fanfic);

        return Result<CreateFanficResponse>.Success(new());
    }
}