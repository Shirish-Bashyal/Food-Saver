using Microsoft.AspNetCore.Mvc;
using Waste_Food_Management.Data;
using Waste_Food_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Waste_Food_Management.Controllers
{
    public class Seller:Controller
    {
        private readonly ApplicationDbContext _context;
        public Seller(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Submit_Sale_Model sp1)

        {
            //  var UserId = Int32.Parse(Request.Cookies["UserId"]);
            //var UserId1 = Request.Cookies["UserId"];
            var SellerId1 = Int32.Parse(Request.Cookies["SellerID"]);
           // UserId = Request.Cookies["UserId"];
            var user = await _context.tbl_seller
             .FirstOrDefaultAsync(m => m.SellerId == SellerId1);
          //  sp1.seller = user;
            _context.tbl_Sale.Add(sp1);
            _context.SaveChanges();




         return RedirectToAction(actionName: "Index", controllerName: "Done");

        }









    }
}
