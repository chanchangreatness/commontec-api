using System.ComponentModel.DataAnnotations;

namespace ComonTecApi.Domain.Models
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
