using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace ComonTecApi.Domain.Models
{
    public class ProductDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int? Quantity { get; set; }
    }
}
