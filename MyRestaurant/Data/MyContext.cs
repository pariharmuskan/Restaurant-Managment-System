using Microsoft.EntityFrameworkCore;
using MyRestaurant.Models;

namespace MyRestaurant.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) :base(options) 
        {
        }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<SubMenu2> SubMenus2 { get; set; }

        public DbSet<Item> Items { get; set; }


        public DbSet<Customer> Customers { get; set; }


        public DbSet<User> Users { get; set; }

       
       
        
    }
}
