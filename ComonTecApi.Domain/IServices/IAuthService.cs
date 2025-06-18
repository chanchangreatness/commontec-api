using ComonTecApi.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Domain.IServices
{
    public interface IAuthService
    {
        Task<Results<Ok<string>, Conflict<string>>> RegisterUser(UserDto request);
        Task<Results<Ok<string>, BadRequest<string>>> Login(UserDto request);
    }
}
