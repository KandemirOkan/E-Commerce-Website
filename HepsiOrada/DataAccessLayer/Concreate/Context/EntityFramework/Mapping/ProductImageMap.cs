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
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            //Sql tablolarımızın kolanlarının propertylerinde yapmak istediğimiz değişiklikleri bu kısımda belirtiyoruz.
            builder.HasOne(x => x.Product).WithMany(x => x.ProductImage).HasForeignKey(x => x.ProductId);
        }
    }
}
