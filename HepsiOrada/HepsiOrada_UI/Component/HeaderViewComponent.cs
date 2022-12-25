using BusinessLogicLayer.Abstract;
using HepsiOrada_UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HepsiOrada_UI.Component
{
    //View Component , Partial View yapısının alternatifidir. Örnek için, ufak bir veritabanı işleminde Controller yapısını kullanmadan veri alıp işlememizi sağlayan yapıdır. Aşağıdaki örnekte Header Class'ın adıyken ViewComponent'ı otomatik olarak görmektedir. Sayfalarımızın Header yapısını bu Component içinde tuttuk. Header'a veri çekmek istediğimizde , Layout'un içinde veri çekemeyiz ama component içinde çekebiliriz, bize böyle bir faydası oldu burada.
    public class HeaderViewComponent:ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HeaderViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            HeaderViewModel model = new HeaderViewModel();
            var categories = categoryService.GetCategory();
            switch (categories.ResultType)
            {
                case Core.Constant.EntityResultType.Success:
                    model.Category = categories.Data.ToList();
                    break;
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
            }
            return View(model);
        }
    }
}
