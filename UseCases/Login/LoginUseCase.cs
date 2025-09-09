using Fanfix.Services.JWT;
using Fanfix.Services.Users;

namespace Fanfix.UseCases.Login;

public class LoginUseCase
(
    IUserService userService,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await userService.GetUserByLogin(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        if (payload.Password != user.Password)
            return Result<LoginResponse>.Fail("User not found");

        var jwt = jWTService.CreateToken(new(
            user.ID, user.Username
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}