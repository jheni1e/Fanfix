using Fanfix.Models;

namespace Fanfix.Services.Users;

public interface IUserService
{
    Task<int> CreateUser(User user);
    Task<User> GetUserByLogin(string Login);
    Task<User> GetUserByID(int ID);
}