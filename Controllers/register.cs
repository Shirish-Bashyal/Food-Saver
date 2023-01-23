
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Waste_Food_Management.Models;
using Waste_Food_Management.Data;
using Microsoft.AspNetCore.Identity;

namespace TechnoSewa.Controllers
{
    public class register : Controller
    {

        string SellerID;
        string BuyerID;
        string UserId;
        string Role1 ;
        private readonly ApplicationDbContext _context;
        public register(ApplicationDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            UserId=Request.Cookies["UserId"];
            Role1= Request.Cookies["Role1"];
            if (UserId != null )
            {
               if(Role1 == "Seller")
                return RedirectToAction(actionName: "Index", controllerName: "Seller");

                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Buyer");
                }

            }
            return View();

        }
        public ActionResult CreateProfile()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateProfile(RegisterModel r1)
        {
            var test = ModelState.IsValid;
            if (ModelState.IsValid)
            {
                _context.tbl_register.Add(r1);
                _context.SaveChanges();



            }


            if (r1.Role == "Seller")
            {

                SellerModel s1 = new SellerModel();
               // s1.Role = r1.Role;
                s1.PhoneNumber= r1.PhoneNumber;
                s1.Address= r1.Address;
                s1.Email= r1.Email;
                s1.FullName= r1.FullName;
                
                var test1 = ModelState.IsValid;
                if (ModelState.IsValid)
                {
                    _context.tbl_seller.Add(s1);
                    _context.SaveChanges();



                }
            }
            else
            {
                BuyerModel s1 = new BuyerModel();
                // s1.Role = r1.Role;
                s1.PhoneNumber = r1.PhoneNumber;
                s1.Address = r1.Address;
                s1.Email = r1.Email;
                s1.FullName = r1.FullName;

                var test2 = ModelState.IsValid;
                if (ModelState.IsValid)
                {
                    _context.tbl_buyer.Add(s1);
                    _context.SaveChanges();



                }

            }





            return RedirectToAction(actionName: "signin", controllerName: "register");
        }



      


        [HttpGet]

        public IActionResult signin()

        {

            RegisterModel _Model = new RegisterModel();

            return View(_Model);

        }

        // Authentication and Authorization
        [HttpPost]
        public IActionResult signin(RegisterModel _Model)

        {



            var status = _context.tbl_register.Where(m => m.Email == _Model.Email && m.Password == _Model.Password ).FirstOrDefault();

            if (status == null)

            {

                ViewBag.LoginStatus = 0;
                return View();

            }

            else

            {

                //var status1 = _context.tbl_register.Where(m => m.Email == _Model.Email && m.Password == _Model.Password && m.Role==_Model.Role).FirstOrDefault();
                if (status.Role == "Seller")
                {
                    var status2 = _context.tbl_seller.Where(m => m.Email == _Model.Email && m.Password == _Model.Password).FirstOrDefault();




                    var cookieOptions = new CookieOptions();

                    cookieOptions.Expires = DateTime.Now.AddDays(30);
                    cookieOptions.Path = "/";


                    Response.Cookies.Append("SellerID", status2.SellerId.ToString(), cookieOptions);
                    Response.Cookies.Append("Role1", status2.Role.ToString(), cookieOptions);
                }
                else
                {
                    var status3 = _context.tbl_buyer.Where(m => m.Email == _Model.Email && m.Password == _Model.Password).FirstOrDefault();

                    var cookieOptions = new CookieOptions();

                    cookieOptions.Expires = DateTime.Now.AddDays(30);
                    cookieOptions.Path = "/";


                    Response.Cookies.Append("BuyerID", status3.BuyerId.ToString(), cookieOptions);
                    Response.Cookies.Append("Role1", status3.Role.ToString(), cookieOptions);

                }



                if (status.Role == "Seller")
                    return RedirectToAction("Index", "Seller");
               
                else

                    return RedirectToAction("Index", "Buyer");




            }
        }
            


                public IActionResult signout()

            {
                //CookieOptions.Expires = DateTime.Now.AddSeconds(1);
                // Session.Abandon();
                //HttpContext.Current.Session.Abandon();
                //string v = Request.Cookies["UserId"];
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Append("UserId", "null", cookieOptions);
                var cookieOptions1 = new CookieOptions();
                cookieOptions1.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Append("Role1", "null", cookieOptions);
                //  Response.Cookies.Append("SomeCookie", "null", cookieOptions);
                //  var UserId = Int32.Parse(Request.Cookies["UserId"]);

                return RedirectToAction(actionName: "signin", controllerName: "register");


            }



        }
    }


