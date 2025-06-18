using ComonTecApi.Domain.Entities;

namespace ComonTecApi.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(string username);
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByUsername(string username);
    }
}
