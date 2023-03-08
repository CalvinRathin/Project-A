using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProject.Models
{
    public class Status
    {
        [Key]
        public int statusId { get; set; }

        [ForeignKey("Order")]
        public int orderId { get; set; }

        public string? status_details { get; set; }

        public Order? Order { get; set; }
    }
}
