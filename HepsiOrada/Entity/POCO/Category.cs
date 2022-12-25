using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    //Sql'e atılacak olan , temel data tabloları
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
