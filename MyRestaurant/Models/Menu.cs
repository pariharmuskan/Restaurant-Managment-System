using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Models
{
    public class Menu
        
    {
        [Key] 
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        
        public byte[] MenuImage { get; set; }
    }
}
