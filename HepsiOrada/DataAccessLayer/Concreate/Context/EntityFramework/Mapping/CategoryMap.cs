using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Context.EntityFramework.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        //Sql tablolarımızın kolanlarının propertylerinde yapmak istediğimiz değişiklikleri bu kısımda belirtiyoruz.
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
