using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    //Product ile Category'nin bağlantısını sağlamak için üretilen ara sınıf
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }  
    }
}
