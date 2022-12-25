using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HepsiOrada_UI.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
