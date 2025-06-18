using Microsoft.EntityFrameworkCore;

namespace ComonTecApi.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
