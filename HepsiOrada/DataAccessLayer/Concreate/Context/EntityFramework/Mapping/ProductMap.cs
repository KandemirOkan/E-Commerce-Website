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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Sql tablolarımızın kolanlarının propertylerinde yapmak istediğimiz değişiklikleri bu kısımda belirtiyoruz.
            builder.Property(x => x.Name).HasColumnName("ProductName").HasColumnType("nvarchar(50)").IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.ProductImage).WithOne(x => x.Product).HasForeignKey(x=>x.ProductId);
        }
    }
}
