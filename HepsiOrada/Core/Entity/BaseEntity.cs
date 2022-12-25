using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public interface IBaseEntity
    {

    }
    public class BaseEntity:IBaseEntity
    {
        public BaseEntity()
        {
            Active = true;
            Delete = false;
            Update = DateTime.Now;
            Create= DateTime.Now;
        }
        public bool Active { get; set; }
        public bool Delete { get; set; }
        public DateTime Update { get; set; }
        public DateTime Create { get; set; }

        public int Id { get; set; }

    }
}
