using Core.BLL;
using Core.Constant;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        EntityResult<IEnumerable<Category>> GetCategory();
    }
}
