using Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BLL
{
    //BLL Servicelere , dolayısıyla esas olarak Managerlara kalıtım veren interface.
    public interface IGenericService<T>
    {
        EntityResult Add(T entity);
        EntityResult Update(T entity);
        EntityResult Delete(T entity);

        EntityResult<IEnumerable<T>> Get();
        EntityResult<T> Get(int id);

    }
}
