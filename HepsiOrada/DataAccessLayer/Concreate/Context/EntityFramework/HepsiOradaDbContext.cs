using DataAccessLayer.Concreate.Context.EntityFramework.Mapping;
using Entity.POCO;
//Giriş, Çıkış , Şifre vs. işlemlerini yapmamızı sağlayan, kullanıcı rolünü belirleyen, kütüphane.
//Entity(database) ve DAL layerlarına proje başlar başlamaz Idendity.EntitiyFramework'ünü kur!!! İleriki aşamalarda unutulup hata verebilir.
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Context.EntityFramework
{
    //Database ile bağlantı kurduğumuz, PoCo'daki tabloları database'e aktarmamızı sağlayan kısım.
    //Database'i ayağa kaldırmak için add-migration yapmalıyız. 
    public class HepsiOradaDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        //Sql server ile bağlantıyı sağlayan method.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bu kısmın çalışması için EntityFrameworkCoreSql ve EntityFrameworkCoreTools paketlerinin NugetPackage'dan indirilmesi gereklidir.
            //Sql server ile bağlantıyı sağlayan asıl-method. MultipleActiveResultSets=true kısmı , ileride modüller-birden çok servisi kullanabilmemiz için gerekli ve önemli*.
            optionsBuilder.UseSqlServer(@"Server=Okan;Database=HepsiOradaDbContext;Trusted_Connection=True;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database katmanında(Entity) çok çoka ilişkiler kurduk. Migration'ın çalışması için Primary keylerimizi tanıtmalıyız. Modelbuilder bunu sağlıyor.
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
            //Sql üzerindeki işlemleri visual studio üzerindeki kodlarla ile yapmalıyız. Sql üzerinden gidersek hata yapma ihtimalimiz artar. Aşağıdaki foreach döngüsü Database Diagram'daki cascade bağlantı tipini No Action yapmamızı sağlıyor.
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x=>x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Mapping ile Sql tablolalardaki kolonların propertylerini ayarlarız.
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductImageMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.Entity<AppRole>().HasData
                (
                    new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                    new AppRole { Id = 2, Name = "UserApp", NormalizedName = "USERAPP" }
                );
            base.OnModelCreating(modelBuilder);
        }
        //Database'e aktarılacak olan tablolalar
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Basket> Basket { get;  set; }

        //Identity.EntityFramework.Core'dan çekince bu propertilere gerek kalmadı.
        //public DbSet<AppRole> AppRole { get; set; }
        //public DbSet<AppUser> AppUser { get; set; }
        //public DbSet<RoleUser> RoleUser { get; set; }
    }
}
