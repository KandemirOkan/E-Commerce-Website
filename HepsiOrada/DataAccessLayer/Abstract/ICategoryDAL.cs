using Core.DAL;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDAL:IRepository<Category>
    {
        IEnumerable<Category> GetCategory();
    }
}
