using DataAccessLayer.Concreate.Context.EntityFramework;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SeedData
{
    //Database'e veri seed'leyeceğimiz class.
    public static class Seed
    {
        public static void SeedData()
        {
            //DAL katmanındaki DBContext'imizin bulunduğu sınıftan bir db nesnesi oluşturduk. Bu nesnenin propertilerinden olan Category,Product,ProductImage,ProductCategory listelerini isimleri ve ilgili resim Url'leri ile dolurduk ve bu nesnedeki değişiklikleri kaydettik?.
            HepsiOradaDbContext db = new HepsiOradaDbContext();
            List<Category> categories = new List<Category>
            {
                new Category{ Name="Bilgisayar",
                    ImageUrl="~/images/bilgisayar.jpg"},//1
                new Category{ Name="Laptop",
                ImageUrl="~/images/laptop.jpg"},//2
                new Category{ Name="Cep Telefonu",
                ImageUrl="~/images/telefon.jpg"},//3
            };
            db.Category.AddRange(categories);
            List<Product> products = new List<Product>()
            {
                new Product{Name="Huawei Matebook D15",Price=12500,Stock=50 },//1
                new Product{Name="Lenovo V15",Price=12336,Stock=150 },//2
                new Product{Name="Dell Inspiron 15",Price=9999,Stock=75 },//3
                new Product{Name="Acer Aspire 3",Price=7299,Stock=25 },//4
                new Product{Name="Monster Abra A7",Price=19499,Stock=35 },//5
                new Product{Name="Macbook Air 13 M1",Price=21000,Stock=45 },//6
            };
            db.Product.AddRange(products);
            db.SaveChanges();

            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory{ CategoryId=2,ProductId=1},
                new ProductCategory{ CategoryId=2,ProductId=2},
                new ProductCategory{ CategoryId=2,ProductId=3},
                new ProductCategory{ CategoryId=2,ProductId=4},
                new ProductCategory{ CategoryId=2,ProductId=5},
                new ProductCategory{ CategoryId=2,ProductId=6},
            };
            db.ProductCategory.AddRange(productCategories);
            db.SaveChanges();

            List<ProductImage> ProductImage = new List<ProductImage>
            {
                new ProductImage{ ProductId=1, URL="~/images/Huawei Matebook D15.jpg"},
                new ProductImage{ ProductId=2, URL="~/images/Lenovo V15.jpg"},
                new ProductImage{ ProductId=3, URL="~/images/Dell Inspiron 15.jpg"},
                new ProductImage{ ProductId=4, URL="~/images/Acer Aspire 3 A315.jpg"},
                new ProductImage{ ProductId=5, URL="~/images/Monster abra a7.jpg"},
                new ProductImage{ ProductId=6, URL="~/images/Macbook air 13 m1.jpg"},
            };
            db.ProductImage.AddRange(ProductImage);
            db.SaveChanges();
        }
    }
}
