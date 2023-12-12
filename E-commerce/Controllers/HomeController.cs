
using E_commerce.Models.context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AplicationDbcontext context;

        public HomeController(AplicationDbcontext context)
        {
            this.context = context;
             
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       public IActionResult Portfolio()
        {
            return View();
        }
       
        public IActionResult Services()
        {

            var ser = context.Products.Where(p => p.productname=="Jasmine").ToList();

            return View( ser);
        }
    }
}