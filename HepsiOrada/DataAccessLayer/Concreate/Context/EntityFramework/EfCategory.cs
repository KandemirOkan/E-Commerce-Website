using DataAccessLayer.Abstract;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Context.EntityFramework
{
    //Category tablolaları için işlemler yapmamızı sağlayan kısım. Sql datalarımızdan Category tablosundaki Product ve Product Categorylerden aktif ve silinmemiş olanlara Select çektiren işlemi aşağıda yaptık.
    public class EfCategory:EfRepository<Category,HepsiOradaDbContext>,ICategoryDAL
    {
        public EfCategory(HepsiOradaDbContext db) : base(db)
        {
            Db = db;
        }

        public HepsiOradaDbContext Db { get; }
        public IEnumerable<Category> GetCategory()
        {
            return Db.Category.Include(x => x.ProductCategory).ThenInclude(x => x.Product).Where(x => x.Active && !x.Delete);
        }
    }
}
