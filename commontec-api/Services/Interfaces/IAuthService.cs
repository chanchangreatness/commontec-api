using ComonTecApi.Entities;
using ComonTecApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Results<Ok<string>, Conflict<string>>> RegisterUser(UserDto request);
        Task<Results<Ok<string>, BadRequest<string>>> Login(UserDto request);
    }
}
