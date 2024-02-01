using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Models
{
    public class SubMenu2
    {
        [Key]
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public byte[] SubMenuImage { get; set; }
        public string Price { get; set; }


        [ForeignKey("Menus")]
        public int MenuId { get; set; }

        public Menu Menus { get; set; }
    }
}
