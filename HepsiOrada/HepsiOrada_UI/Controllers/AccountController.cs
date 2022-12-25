using Entity.POCO;
using HepsiOrada_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HepsiOrada_UI.Controllers
{
    //Bu sınıfta login ve register sayfalarının get ve post özelliklerini giriyoruz.UserManager ve Sıgninmanager sınıfları yardımıyla kullanıcı girişi , kayıtının doğru yapılıp yapılamadığını kontrol edebiliyoruz.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //Login sayfasına bizi götürmeye yarayan basic method.
        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            TempData["rtnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var sign = await signInManager.PasswordSignInAsync(userName, password, false, false);
            if (sign.Succeeded)
            {
                if (TempData["rtnUrl"]!=null)
                {
                    return Redirect(TempData["rtnUrl"].ToString());
                }
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        //Register sayfasına bizi götürmeye yarayan basic method.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Register sayfasında kayıt işlemi yapabilmek için sunuyu oluşturduğumuz dataları göndermeyi sağlayan HttpPost methodu.
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Geçerli bilgiler girilirse yeni kullanıcı oluşturmamızı sağlayan kısım.
                AppUser appUser = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };
                var IdentityResult =
                    await userManager.CreateAsync(appUser, model.Password);

                //Yeni kullanıcı kayıdı oluşturulamazsa, buna sebep olan hatayı dönen method.
                if (!IdentityResult.Succeeded)
                {
                    foreach (var item in IdentityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
                else
                {
                    //Role girence hata veriyor şimdilik böyle kalsın.
                    await userManager.AddToRoleAsync(appUser, "UserApp");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

        //Kullanıcı çıkışı yaparak anasayfaya yönlendirme methodu.
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }
}
