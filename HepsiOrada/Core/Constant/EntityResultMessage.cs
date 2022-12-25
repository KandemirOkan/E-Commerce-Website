using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{
    public class EntityResultMessage
    {
        public static string Add()
        {
            return "Ekleme Başarılı";
        }
        public static string Warning()
        {
            return "Beklenmedik Bir Sorun";
        }
        public static string Error(Exception ex)
        {
            return "Başarısız"+ ex.ToInnest().Message;
        }
    }
}
