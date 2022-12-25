using BusinessLogicLayer.Abstract;
using HepsiOrada_UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HepsiOrada_UI.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        //Views/Shared/Header/Default.cshtml'deki Tag helper yardımıyla gelen id'yi alıyor.
        public IActionResult Index(int Id)
        {
            CategoryDetailViewModel model = new CategoryDetailViewModel();
            model.Category = categoryService.GetCategory().Data.ToList();
            var result = productService.GetProductbyCategoryId(Id);
            switch (result.EntityResultType)
            {
                case Core.Constant.EntityResultType.Success:
                    model.ProductDto = result.Data.ToList();
                    return View(model);
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
            }
            return View();
        }
    }
}
