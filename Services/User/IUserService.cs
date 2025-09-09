using Fanfix.Models;

namespace Fanfix.Services.Users;

public interface IUserService
{
    Task<int> CreateUser(User user);
    Task<User> GetUserByUsername(string Username);
    Task<User> GetUserByID(int ID);
}