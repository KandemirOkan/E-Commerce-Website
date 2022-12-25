using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{
    public class EntityResult
    {
        //Datalar için yapılan işlemin olup olupmadığını yada hangi işlem yapıldığını anlaşılır bir şekilde geri dönüş yapılmasını sağlayan sınıf.
        public object Message { get; }
        public EntityResultType ResultType { get; set; }
        public EntityResult(object message, EntityResultType resultType=EntityResultType.Success)
        {
            Message = message;
            ResultType = resultType;
        }
    }
    public class EntityResult<T> : EntityResult
    {
        public T Data { get; set; }
        public EntityResultType EntityResultType { get; set; }

        //:base kullanımı=> Kalıtım alan alt sınıf propertyleri çekiyor ama bunları constructure'ına yansıtamıyor. Aynı propertyi alt sınıf içerisinde yazarsak da bu sefer üst sınıftakini görüp alttakini görmediği için gene cons. içine alamıyor. Dolayısıyla bu sınıfta kullanıldığı gibi kullanmak gerekiyor.
        public EntityResult(T data, object Message,EntityResultType ResultType=EntityResultType.Success):base(Message,ResultType)
        {
            Data = data;
        }
    }
}
