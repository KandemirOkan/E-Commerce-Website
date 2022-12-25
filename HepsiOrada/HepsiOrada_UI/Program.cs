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
            //DAL katman�ndaki Seed s�n�f�nda database'e basaca��m�z �r�n s�n�flar�n� girdik. SeedData() methodunu sadece 1 kere run ederek , sunucumuza datalar� bast�k. ProductImage-Product Foreign Key ba�lant�s� hatas� verdi, �imdilik ��zemedik , ama datalar� servera bast�k. 
            //Seed.SeedData();
            var builder = WebApplication.CreateBuilder(args);

            //MVC paterninin MVC framework servisini kullanabilmek i�in ekledi�imiz k�s�m.
            builder.Services.AddControllersWithViews();
            //Scoped keyword'� => Uygulama i�erisinde ba��ml�l�k olu�turdu�umuz request sonlanana kadar ayn� nesneyi kullanmas�n�, farkl� �a�r� geldi�inde yeni bir nesne yaratmas�n� sa�lar. 
            //Mesela UI katman�nda HomeController constructure'�na ICategoryService verdi�imizde alttaki servis ayar�ndan CategoryManager'� kullanmas�n� sa�l�yoruz. 
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            //DAL'daki ICategoryDAL'� EfCategory'e
            builder.Services.AddScoped<ICategoryDAL, EfCategory>();
            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDAL, EfProduct>();
            builder.Services.AddScoped<IBasketService, BasketManager>();
            builder.Services.AddScoped<IBasketDAL,EfBasket>();
            //EfCategory'i db context'e kadar inene y�nlendiri�imiz ayarlar.
            builder.Services.AddScoped<HepsiOradaDbContext>();

            //Asp.net core'un Identity k�t�phanesini kullanabilmek i�in eklememiz gereken servis ayarlar�n� bu k�s�mdan yap�yoruz.
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
            //Kullan�c� giri� yapt�m� yapmad� m� takip etmemizi sa�layan servis. (Eklemeyi unuttup g�nlerce beni u�ra�t�rm��t�.)
            app.UseAuthentication();
            app.UseAuthorization();
            //Att���m�z requestin hangi adrese(url) at�ld���n� belirten k�s�md�r. 
            app.UseEndpoints(endpoints =>
            {
                //url k�sm�nda bir y�nledirme yapmadan istek atarsak www.HepsiOrada.com gibi Controller olarak home'u g�r�r, action olarak Index'i g�r�r. www.HepsiOrada.com/Shared/Index gibi. Hen�z olmad� ama bakaca��z.
                endpoints.MapDefaultControllerRoute();
            });
            
            app.Run();
        }
    }
}