using Core.BLL;
using Core.Constant;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        EntityResult<IEnumerable<ProductDTO>> GetProductbyCategoryId(int categoryid);
        EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product,bool>> expression = null, string[] navPropery=null);
		EntityResult<IEnumerable<ProductDTO>> GetBasketByProductID(int userId);
	}
}
