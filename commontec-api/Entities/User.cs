using System.ComponentModel.DataAnnotations.Schema;

namespace ComonTecApi.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
