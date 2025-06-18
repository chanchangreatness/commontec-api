using ComonTecApi.Domain.Entities;

namespace ComonTecApi.Domain.IServices
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
