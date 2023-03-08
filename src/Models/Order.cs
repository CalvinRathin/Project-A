using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaProject.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        [ForeignKey("Pizza")]
        public int pizzaId { get; set; }
        public Pizza? Pizza { get; set; }


        public DateTime orderDate { get; set; }

        public string? style { get; set; }

        public string? add_flavour { get; set; }

        public int no_of_pizza { get; set; }

        public string? address { get; set; }

        public int total_amount { get; set; }
    }
}
