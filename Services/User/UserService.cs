using Fanfix.Models;
using Microsoft.EntityFrameworkCore;

namespace Fanfix.Services.Users;

public class UserService(FanfixDbContext ctx) : IUserService
{
    public async Task<int> CreateUser(User user)
    {
        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
        return user.ID;
    }

    public async Task<User> GetUserByID(int ID)
    {
        return await ctx.Users.FirstOrDefaultAsync(
            u => u.ID == ID
        );
    }

    public async Task<User> GetUserByLogin(string Login)
    {
        return await ctx.Users.FirstOrDefaultAsync(
            u => u.Username == Login || u.Email == Login
        );
    }
}