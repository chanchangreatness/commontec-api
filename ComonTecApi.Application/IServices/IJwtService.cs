using ComonTecApi.Domain.Entities;

namespace ComonTecApi.Application.IServices
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
