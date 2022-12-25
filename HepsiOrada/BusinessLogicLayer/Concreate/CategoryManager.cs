using BusinessLogicLayer.Abstract;
using Core.BLL;
using Core.Constant;
using DataAccessLayer.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    //BLL'deki işlemleri yapılmasını sağlayan , Core'daki IGenericService'den , abstractaki ara serviceler aracılığıyla kalıtım alan sınıf.
    //Sonuç olarak hem sql işlemlerini DAL katmanına yaptırıyor, hem de sonuçları mantıklı birer dönüş olarak BLL katmanında bize döndürülmesini sağlıyan sınıf.
    public class CategoryManager : ICategoryService
    {
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            CategoryDAL = categoryDAL;
        }

        public ICategoryDAL CategoryDAL { get; }

        public EntityResult<IEnumerable<Category>> GetCategory()
        {
            try
            {
                var result = CategoryDAL.GetCategory();
                if (result!=null&&result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Category>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Category>>(null, "NotFound", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Category>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        EntityResult IGenericService<Category>.Add(Category entity)
        {
            try
            {
                //Eğer DAL katmanı aracılığı ile database başarılı bir ekleme gerçekleştirilirse. Bize mesaj olarak Başarılı ekleme ve Success dönülmesini sağlayacak olan işlem.
                if (CategoryDAL.Add(entity))
                {
                    return new EntityResult(EntityResultMessage.Add());
                }
                //Eğer başarısız olursa Beklenmedik bir sonuç dönecek.
                return new(EntityResultMessage.Warning());
            }
            catch (Exception ex)
            {
                //Hata vermesi durumunda Başarısız dönüp ToInnest() methodu çağırarak InnerException hatasını engellemeye yarayan geri dönüş.
                return new(EntityResultMessage.Error(ex), EntityResultType.Error);
            }
        }

        EntityResult IGenericService<Category>.Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        EntityResult<IEnumerable<Category>> IGenericService<Category>.Get()
        {
            throw new NotImplementedException();
        }

        EntityResult<Category> IGenericService<Category>.Get(int id)
        {
            throw new NotImplementedException();
        }

        EntityResult IGenericService<Category>.Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
