    using BusinessLogicLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Abstract;

namespace HepsiOrada_UI.Controllers
{
    //Sadece kullanıcıların sepet işlemi yapabilmesini, adminlerin (mesela) sepet işlemi yapamamasını sağlayan attribute.
    [Authorize(Roles = "UserApp")]
    public class BasketController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IProductService productService;
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService,UserManager<AppUser> userManager,IProductService productService)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.basketService = basketService;
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int count, int productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.AddToBasket(new Entity.DTO.BasketDTO
            {
                Count = count,
                ProductId = productId,
                UserID = user.Id
            });
            switch (result.EntityResultType)
            {
                case Core.Constant.EntityResultType.Success:

                    //Asp.Net Core Mvc kütüphanesinde bulunan ve 200 (Http durum kodu) işlemin başarılı olduğunu ifade eden kodu verdiren method.
                    return Ok();
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            //Asp.Net Core Mvc kütüphanesinde bulunan ve 404 (Http durum kodu) no'lu hata kodunu verdiren method.
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> RefreshBasketCount()
        {
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.Get(u.Id);
            switch (result.EntityResultType)        
            {
                case Core.Constant.EntityResultType.Success:
                    return Ok(result.Data.Sum(x=>x.Count));
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();
        }
        public async Task<IActionResult> Sepet()
        {
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            var result = productService.GetBasketByProductID(u.Id);
            switch (result.EntityResultType)
            {
                case Core.Constant.EntityResultType.Success:
                    return View(result.Data);   
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }
        public async Task<IActionResult> CountChange(int id,int count)
        {
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.Update(count, id, u.Id);
            switch (result.EntityResultType)
            {
                case Core.Constant.EntityResultType.Success:
                    return Ok();
                case Core.Constant.EntityResultType.Error:
                    break;
                case Core.Constant.EntityResultType.NotFound:
                    break;
                case Core.Constant.EntityResultType.NonVAlidation:
                    break;
                case Core.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
