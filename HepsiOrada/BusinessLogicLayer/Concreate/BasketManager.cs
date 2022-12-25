using BusinessLogicLayer.Abstract;
using Core.Constant;
using DataAccessLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL basketDAL;

        public BasketManager(IBasketDAL basketDAL)
        {
            this.basketDAL = basketDAL;
        }
        public EntityResult<IEnumerable<Basket>> AddToBasket(BasketDTO basketDTO)
        {
            try
            {
                var basket = basketDAL.AddToBasket(basketDTO).ToList();
                if (basket!=null&&basket.Count>0)
                {
                    return new EntityResult<IEnumerable<Basket>>(basket, "Success");
                }
                return new EntityResult<IEnumerable<Basket>>(null, "Notfound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Basket>> Get(int UserID)
        {
            try
            {
                string[] dizi = new string[]
                {
                    "Product","AppUser"
                };
                var result = basketDAL.GetEntity(x => x.AppUserId == UserID, dizi);
                if (result!=null&&result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Basket>>(result, "Success");
                }
                return new EntityResult < IEnumerable<Basket>>(null, "Not Found", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<int> Update(int count, int ProductID, int UserID)
        {
            var basket = basketDAL.GetEntity(x => x.AppUserId == UserID && x.ProductId == ProductID).FirstOrDefault();
            basket.Count = count;
            basketDAL.Update(basket);
            return new EntityResult<int>(basket.Count, EntityResultType.Success);
        }
    }
}
