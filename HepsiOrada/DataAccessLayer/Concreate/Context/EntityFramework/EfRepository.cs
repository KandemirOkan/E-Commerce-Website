using Core.DAL;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Context.EntityFramework
{
    //Entity(database) katmanında (ekle,sil,güncelle gibi) değişiklikler yapılmasını sağlayan DAL katmanındaki kısım.
    public class EfRepository<TEntity,TDbContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
        where TDbContext:DbContext
    {
        public EfRepository(TDbContext db)
        {
            Db = db;
        }

        public TDbContext Db { get; }

        public bool Add(TEntity entity)
        {
            Db.Add(entity);
            return Db.SaveChanges()>0?true:false;
        }

        public bool Delete(TEntity entity)
        {
            Db.Update(entity);
            return Db.SaveChanges() > 0 ? true : false;
        }

        public TEntity Get(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null)
        {
            IQueryable<TEntity> entities = null;
            if (expression == null)
            {
                entities = Db.Set<TEntity>();
            }
            else
            {
                entities = Db.Set<TEntity>().Where(expression);
            }
            if (navProperty==null)
            {
                return entities;
            }
            else
            {
                foreach (var item in navProperty)
                {
                    entities = entities.Include(item);
                }
                return entities;
            }
        }

        public bool Update(TEntity entity)
        {
            Db.Update(entity);
            return Db.SaveChanges() > 0 ? true : false;
        }
    }
}
