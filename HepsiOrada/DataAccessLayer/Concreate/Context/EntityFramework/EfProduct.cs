using DataAccessLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Context.EntityFramework
{
    //Product tablolaları için işlemler yapmamızı sağlayan kısım. 
    public class EfProduct:EfRepository<Product,HepsiOradaDbContext>,IProductDAL
    {
        public EfProduct(HepsiOradaDbContext db) : base(db)
        {
            Db = db;
        }

        public HepsiOradaDbContext Db { get; }

		public IEnumerable<ProductDTO> GetBasketByProductId(int userId)
		{
			var result =
	            from product in Db.Product
	            join basket in Db.Basket on product.Id equals basket.ProductId
	            join user in Db.Users on basket.AppUserId equals user.Id
	            where user.Id == userId
	            select new ProductDTO
	{
		Id = product.Id,
		Name = product.Name,
		Price = product.Price,
		Stok = product.Stock,
		ImageUrl = Db.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).URL,
		BasketCount = basket.Count
	};
			return result;
		}


		//select
		//C.CustomerID,c.CompanyName,
		//sum(od.UnitPrice* od.Quantity)
		//from Orders o join Customers c on o.CustomerID=c.CustomerID
		//join [Order Details] od on od.OrderID= o.OrderID

		//sql'daki joinlerle bağlantı yapıp select çektirdiğimiz kısmın aynısını, C# kodlarıyla Data Access Layer'da yapmamızı sağlayan method.
		public IEnumerable<ProductDTO> GetProductbyCategoryId(int categoryid)
        {
            var result =
                from Product in Db.Product
                join ProductCategory in Db.ProductCategory
                on Product.Id equals ProductCategory.ProductId
                join Category in Db.Category
                on ProductCategory.CategoryId equals Category.Id
                where ProductCategory.CategoryId == categoryid
                select new ProductDTO
                {
                    CategoryName = Category.Name,
                    Id = Product.Id,
                    Name = Product.Name,
                    Price = Product.Price,
                    Stok = Product.Stock,
                    ImageUrl = Db.ProductImage.FirstOrDefault(x => x.ProductId == Product.Id).URL,
                    CategoryId = categoryid,
                };
                return result;
        }
    }
}
