using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
    }
}
