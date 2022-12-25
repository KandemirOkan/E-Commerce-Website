using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class ProductDTO
    {
        //DTO = Data Transfer Object
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stok { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public decimal? BasketCount { get; set; }
    }
}
