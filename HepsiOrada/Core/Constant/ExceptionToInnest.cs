using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{
    public static class ExceptionToInnest
    {
    public static Exception ToInnest(this Exception ex)
        {
            if (ex.InnerException!=null)
            {
                return ex.InnerException.ToInnest();
            }
            return ex;
        }
    }
}
