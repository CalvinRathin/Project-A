using System.ComponentModel.DataAnnotations;

namespace PizzaProject.Models
{
    public class Pizza
    {
        [Key]
        public int pizzaId { get; set; }
        public string? pizzaName { get; set; }
        public string? type { get; set; }
        public string? speciality { get; set; }
        public string? crust { get; set; }
        public int price { get; set; }
        public int? no_of_slices { get; set; }
        public string? size { get; set; }
        public ICollection<Order>? Orders { get; set; }

        
    }
}
