using ComonTecApi.Domain.Entities;
using ComonTecApi.Domain.IRepositories;
using ComonTecApi.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace ComonTecApi.Infrastracture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserExist(string username)
        {
            return await _context.Users.AnyAsync(e => e.Username == username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var entity = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Username == username);
        }
    }
}
