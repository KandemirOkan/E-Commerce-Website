using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    //Product ile Image'ın bağlantısını sağlamak için üretilen ara sınıf
    public class ProductImage:BaseEntity
    {
        public string URL { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
