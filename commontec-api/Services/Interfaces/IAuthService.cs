using ComonTecApi.Entities;
using ComonTecApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Results<Ok, Conflict>> RegisterUser(UserDto request);
        Task<Results<Ok<string>, BadRequest>> Login(UserDto request);
    }
}
