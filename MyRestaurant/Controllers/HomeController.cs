using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Models;
using System.Diagnostics;
using MyRestaurant.Data;
using MyRestaurant.Models;
using MyRestaurant.Data;

namespace TaskResturant.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext taskDemoDbContext;


        public HomeController(MyContext taskDemoDbContext)
        {
            this.taskDemoDbContext = taskDemoDbContext;
        }

        List<SubMenu> li = new List<SubMenu>();
        public IActionResult Index()
        {
            return View();
        }
        


        [HttpGet]
        public async Task<IActionResult> ListView()
        {
            var menus = await taskDemoDbContext.Menus.ToListAsync();
            return View(menus);
        }

        public IActionResult Cart()
        {
            return View();
        }




        //[HttpPost]
        //public IActionResult SubMenuView(int id)
        //{
        //SubMenu2 p = taskDemoDbContext.SubMenus2.Where(x => x.SubMenuId == id).SingleOrDefault();

        //SubMenu2 sub = new SubMenu2();
        //sub.SubMenuId = id;
        //sub.SubMenuName = sub.SubMenuName;
        //sub.SubMenuImage = sub.SubMenuImage;

        //if (TempData["SubMenu"] == null)
        //{
        //    li.Add(sub);

        //    TempData["SubMenu"] = li;

        //[HttpGet]
        //public async Task<IActionResult> SubMenuView()
        //{
        //    var menus = await taskDemoDbContext.SubMenus2.ToListAsync();
        //    return View(menus);
        //}
        //}
        //[HttpGet]
        //public async Task<IActionResult> SubMenuView()
        //{
        //    var menus = await taskDemoDbContext.SubMenus2.ToListAsync();
        //    return View();
        //}
        //[HttpPost]
        public IActionResult SubMenuView(int menuId)
            {
            TempData["menuId"] = menuId;

            var subMenus = taskDemoDbContext.SubMenus2
                               .Where(subMenu => subMenu.Menus.MenuId == menuId)
                               .ToList();
                var menus = taskDemoDbContext.SubMenus2.ToList();

            return View(menus);
        }
        public IActionResult FetchSubMenuDataById()
        {
            int? menuId = TempData["menuId"] as int?;

            var subMenus = taskDemoDbContext.SubMenus2
                       .Where(subMenu => subMenu.MenuId == menuId)
                       .ToList();

            return Json(subMenus);

           
        }

        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Bill()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Customer customer)
        {

            taskDemoDbContext.Customers.Add(customer);

            taskDemoDbContext.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewCustomer()
        {
            var employees = await taskDemoDbContext.Customers.ToListAsync();
            return View(employees);
        }

        [HttpPost]
        public ActionResult UpdateData(Customer model)
        {
            if (ModelState.IsValid)
            {
                taskDemoDbContext.Entry(model).State = EntityState.Modified;
                taskDemoDbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await taskDemoDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerName == username);
            var pass = await taskDemoDbContext.Customers.FirstOrDefaultAsync(x => x.Password == password);

            if (user != null && pass != null)
            {

                return RedirectToAction("listview", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", "Invalid username or password");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpDelete]

        public async Task<IActionResult> DelCustomer(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var cust = await taskDemoDbContext.Customers.FindAsync(Id);
            if (cust != null)
            {
                taskDemoDbContext.Customers.Remove(cust);
                await taskDemoDbContext.SaveChangesAsync();
                return Ok();
            }
            return RedirectToAction("ViewCustomer", "Home");

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}