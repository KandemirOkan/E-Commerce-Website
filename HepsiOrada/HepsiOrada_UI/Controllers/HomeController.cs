using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HepsiOrada_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        //Database'e dışarıda ulaşılamasın diye HomeController constructe'ı içine ICategoryService interface'i veriyoruz.
        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
