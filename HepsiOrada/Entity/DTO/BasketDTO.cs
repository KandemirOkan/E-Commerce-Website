using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class BasketDTO
    {
        public int? UserID { get; set; }
        public int? ProductId { get; set; }
        public int Count { get; set; }
    }
}
