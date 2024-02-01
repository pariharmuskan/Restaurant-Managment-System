using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Models
{
    public class SubMenu
    {
        //internal string SubMenuPrice;

        [Key]
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public byte[] SubMenuImage { get; set; }
        public string Price { get; set; }
        
       


    }
}
