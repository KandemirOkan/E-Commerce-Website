using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseEntity,new()
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);

        IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null);
    }
}
