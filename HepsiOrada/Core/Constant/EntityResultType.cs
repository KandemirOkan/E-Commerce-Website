using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{
    public enum EntityResultType
    {
        //Yapılan işlemin geri dönüşünde kullanılacak olan, işlem sonucunun tipidir
            Success,
            Error,
            NotFound,
            NonVAlidation,
            Warning,
    }
}
