using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    //Microsoft.AspNetCore.Identity; framework'ünden kullanıcı rolünü çeken sınıf. int parametresi verdik çünkü id çekecek.
    public class AppRole:IdentityRole<int>
    {
    }
}
 