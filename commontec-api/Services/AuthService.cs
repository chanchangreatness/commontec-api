using ComonTecApi.Services.Interfaces;
using ComonTecApi.Entities;
using ComonTecApi.Models;
using ComonTecApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ComonTecApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;


        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<Results<Ok<string>, Conflict<string>>> RegisterUser(UserDto request)
        {
            if (await _userRepository.IsUserExist(request.Username))
            {
                return TypedResults.Conflict("Username already exists");
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.Username = request.Username;
            user.Password = hashedPassword;

            await _userRepository.AddUserAsync(user);

            return TypedResults.Ok("Successfully created User");
        }

        public async Task<Results<Ok<string>, BadRequest<string>>> Login(UserDto request)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);

            if (user is null)
            {
                return TypedResults.BadRequest("Invalid credentials");
            }

            var passwordHasher = new PasswordHasher<User>();

            if (passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                return TypedResults.BadRequest("Invalid credentials");
            }

            return TypedResults.Ok(_jwtService.CreateToken(user));
        }
    }
}
