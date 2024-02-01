using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Data;
using MyRestaurant.Models;
//using MyRestaurant.Migrations;
using MyRestaurant.Data;
using MyRestaurant.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRestaurant.Controllers
{
    public class AddMenuController : Controller
    {

        private readonly MyContext _taskDemoDbContext;


        public AddMenuController(MyContext taskDemoDbContext)


        {
            _taskDemoDbContext = taskDemoDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        public async Task<IActionResult> Index(Menu menu, List<IFormFile> MenuImage)
        {
            foreach (var item in MenuImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);

                        menu.MenuImage = stream.ToArray();

                    }
                }
            }

            _taskDemoDbContext.Menus.Add(menu);
            _taskDemoDbContext.SaveChanges();
            return View();
        }


        //SubMenu COntroller 


        [HttpGet]
        public IActionResult SubMenu2()
        {
            ViewData["MenuId"]=new SelectList(_taskDemoDbContext.Menus,"MenuId", "MenuId");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubMenu2(SubMenu2 submenu, List<IFormFile> SubMenuImage)
        {
            foreach (var item in SubMenuImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);

                        submenu.SubMenuImage = stream.ToArray();

                    }
                }
            }

            _taskDemoDbContext.SubMenus2.Add(submenu);
            _taskDemoDbContext.SaveChanges();
            return View();
        }
    }
}
