using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SpicyRestaurant.UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}