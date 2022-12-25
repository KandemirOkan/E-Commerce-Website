using Core.BLL;
using Core.Constant;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IBasketService
    {
        EntityResult<IEnumerable<Basket>> AddToBasket(BasketDTO basketDTO);
        EntityResult<IEnumerable<Basket>> Get(int UserID);
        EntityResult<int> Update(int count, int ProductID, int UserID);

    }
}
