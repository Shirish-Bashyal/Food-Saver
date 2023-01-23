using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waste_Food_Management.Data;
using Waste_Food_Management.Models;

namespace Waste_Food_Management.Controllers
{
    public class Buyer:Controller
    {
        private readonly ApplicationDbContext _context;
        public Buyer(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // var result = await _context.tbl_register.Where(x => x.Role == "Technician").ToListAsync();
            List<Submit_Sale_Model> result = new List<Submit_Sale_Model>();
            //var cookieOptions = new CookieOptions();

            //cookieOptions.Expires = DateTime.Now.AddDays(30);
            //cookieOptions.Path = "/";


            //Response.Cookies.Append("sale_item",result., cookieOptions);
            

            result = await _context.tbl_Sale.Where(x => x.IsBooked == false).ToListAsync();
            return View(result);












            //return View(result);
            // return View(await _context.profile.ToListAsync());
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult Index()
        //{

        //}











        [HttpGet]
        public IActionResult WillBuy(int a)
        {

            //var cookieOptions = new CookieOptions();

            //cookieOptions.Expires = DateTime.Now.AddDays(30);
            //cookieOptions.Path = "/";


            //Response.Cookies.Append("sale_item",, cookieOptions);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public IActionResult WillBuy()
        {






            return RedirectToAction(actionName: "Index", controllerName: "Home");

        }













    }
}
