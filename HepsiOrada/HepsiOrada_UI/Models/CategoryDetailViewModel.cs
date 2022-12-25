using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiOrada_UI.Models
{
    public class CategoryDetailViewModel
    {
        public List<ProductDTO> ProductDto { get; set; }
        public List<Category> Category { get; set; }
    }
}
