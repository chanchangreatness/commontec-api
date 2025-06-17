using ComonTecApi.Entities;
using ComonTecApi.Models;

namespace ComonTecApi.Services.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
