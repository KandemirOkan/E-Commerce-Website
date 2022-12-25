using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Context.EntityFramework;
using DataAccessLayer.SeedData;
using Entity.POCO;
using HepsiOrada_UI.CustomValidation;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HepsiOrada_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DAL katmanýndaki Seed sýnýfýnda database'e basacaðýmýz ürün sýnýflarýný girdik. SeedData() methodunu sadece 1 kere run ederek , sunucumuza datalarý bastýk. ProductImage-Product Foreign Key baðlantýsý hatasý verdi, þimdilik çözemedik , ama datalarý servera bastýk. 
            //Seed.SeedData();
            var builder = WebApplication.CreateBuilder(args);

            //MVC paterninin MVC framework servisini kullanabilmek için eklediðimiz kýsým.
            builder.Services.AddControllersWithViews();
            //Scoped keyword'ü => Uygulama içerisinde baðýmlýlýk oluþturduðumuz request sonlanana kadar ayný nesneyi kullanmasýný, farklý çaðrý geldiðinde yeni bir nesne yaratmasýný saðlar. 
            //Mesela UI katmanýnda HomeController constructure'ýna ICategoryService verdiðimizde alttaki servis ayarýndan CategoryManager'ý kullanmasýný saðlýyoruz. 
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            //DAL'daki ICategoryDAL'ý EfCategory'e
            builder.Services.AddScoped<ICategoryDAL, EfCategory>();
            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDAL, EfProduct>();
            builder.Services.AddScoped<IBasketService, BasketManager>();
            builder.Services.AddScoped<IBasketDAL,EfBasket>();
            //EfCategory'i db context'e kadar inene yönlendiriðimiz ayarlar.
            builder.Services.AddScoped<HepsiOradaDbContext>();

            //Asp.net core'un Identity kütüphanesini kullanabilmek için eklememiz gereken servis ayarlarýný bu kýsýmdan yapýyoruz.
            builder.Services.AddIdentity<AppUser, AppRole>(x =>
                {
                    x.Password.RequireUppercase = true;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireDigit = true;
                    x.Password.RequiredLength = 5;
                    x.User.RequireUniqueEmail = true;
                    x.Password.RequireNonAlphanumeric = true;
                })
                .AddErrorDescriber<ErrorDescriberAccount>()
                .AddEntityFrameworkStores<HepsiOradaDbContext>();
            builder.Services.AddDbContext<HepsiOradaDbContext>();
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //Kullanýcý giriþ yaptýmý yapmadý mý takip etmemizi saðlayan servis. (Eklemeyi unuttup günlerce beni uðraþtýrmýþtý.)
            app.UseAuthentication();
            app.UseAuthorization();
            //Attýðýmýz requestin hangi adrese(url) atýldýðýný belirten kýsýmdýr. 
            app.UseEndpoints(endpoints =>
            {
                //url kýsmýnda bir yönledirme yapmadan istek atarsak www.HepsiOrada.com gibi Controller olarak home'u görür, action olarak Index'i görür. www.HepsiOrada.com/Shared/Index gibi. Henüz olmadý ama bakacaðýz.
                endpoints.MapDefaultControllerRoute();
            });
            
            app.Run();
        }
    }
}