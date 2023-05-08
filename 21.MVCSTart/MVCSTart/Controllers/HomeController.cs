using Microsoft.AspNetCore.Mvc;
using MVCSTart.Models;

namespace MVCSTart.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
         

            TempData["Students"]="Tempden gonderilen data";

            return RedirectToAction("About");
        }
        public IActionResult About()
        {
            

            return View();
        }

    }
}
