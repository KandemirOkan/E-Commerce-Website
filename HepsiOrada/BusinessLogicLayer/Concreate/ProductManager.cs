using BusinessLogicLayer.Abstract;
using Core.BLL;
using Core.Constant;
using DataAccessLayer.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class ProductManager : IProductService
    {
        //BLL'deki işlemleri yapılmasını sağlayan , Core'daki IGenericService'den , abstractaki ara serviceler aracılığıyla kalıtım alan sınıf.
        //Sonuç olarak hem sql işlemlerini DAL katmanına yaptırıyor, hem de sonuçları mantıklı birer dönüş olarak BLL katmanında bize döndürülmesini sağlıyan sınıf.
        private readonly IProductDAL productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

		public EntityResult<IEnumerable<ProductDTO>> GetBasketByProductID(int userId)
		{
			try
			{
				var result = productDAL.GetBasketByProductId(userId);
				if (result != null && result.Count() > 0)
				{
					return new EntityResult<IEnumerable<ProductDTO>>(result, "Success");
				}
				return new EntityResult<IEnumerable<ProductDTO>>(null, "NotFound", EntityResultType.NotFound);
			}
			catch (Exception ex)
			{

				return new EntityResult<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
			}
		}

		public EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product, bool>> expression = null, string[] navPropery = null)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<ProductDTO>> GetProductbyCategoryId(int categoryid)
        {
            try
            {
                var result = productDAL.GetProductbyCategoryId(categoryid);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<ProductDTO>>(result, "Success");
                }
                return new EntityResult<IEnumerable<ProductDTO>>(null, "Not Found", EntityResultType.NotFound);

            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        EntityResult IGenericService<Product>.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        EntityResult IGenericService<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        EntityResult<IEnumerable<Product>> IGenericService<Product>.Get()
        {
            throw new NotImplementedException();
        }

        EntityResult<Product> IGenericService<Product>.Get(int id)
        {
            throw new NotImplementedException();
        }

        EntityResult IGenericService<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
