using Core.DAL;
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
    public class EfBasket : EfRepository<Basket, HepsiOradaDbContext>, IBasketDAL
    {
        //Burada kullanıcıdan aldığımız kullanıcı Id'si ve Product Id'sini ve Count'u database'e ekliyoruz. Eğer kullanıcı + product Id varsa sadece count artıyor, yoksa hepsini ekliyor.
        private readonly HepsiOradaDbContext db;

        public EfBasket(HepsiOradaDbContext db):base(db)
        {
            this.db = db;
        }
        public IEnumerable<Basket> AddToBasket(BasketDTO basketDTO)
        {
            var basket = db.Basket.FirstOrDefault(x=>x.AppUserId==basketDTO.UserID&&x.ProductId==basketDTO.ProductId);
            if (basket==null)
            {
                db.Basket.Add(new Basket
                {
                    AppUserId = (int)basketDTO.UserID,
                    ProductId = (int)basketDTO.ProductId,
                    Count = (int)basketDTO.Count,
                });
                db.SaveChanges();
            }
            else
            {
                basket.Count += basketDTO.Count;
                db.SaveChanges();
            }
            return db.Basket.Where(x => x.AppUserId == basketDTO.UserID);

        }
    }
}
