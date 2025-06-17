using ComonTecApi.Entities;

namespace ComonTecApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(string username);
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByUsername(string username);
    }
}
