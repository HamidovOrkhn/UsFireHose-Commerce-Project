using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class ProductImageFluent : IEntityTypeConfiguration<ProductImage>
    {

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("productimages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            //builder.Property(x => x.Product).HasColumnName("product");
            builder.Property(x => x.ProductId).HasColumnName("productid");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(x => x.UpdatedDate).HasColumnName("updateddate");
        }

    }
}
