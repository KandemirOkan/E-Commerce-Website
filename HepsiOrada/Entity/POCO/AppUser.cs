using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    //Microsoft.AspNetCore.Identity; framework'ünden kullanıcıyı(bilgileri vs.) çeken sınıf. int parametresi verdik çünkü id çekecek.
    public class AppUser : IdentityUser<int>
    {
        public string? adress { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
