using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class ProductCategoryFluent : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("productcategories");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x=>x.Description).HasColumnName("description");
            builder.Property(x=>x.ImagePath).HasColumnName("imagepath");
            builder.Property(x => x.ParentId).HasColumnName("parentid");
            builder.Property(x=>x.Slug).HasColumnName("slug");
            builder.Property(x=>x.Status).HasColumnName("status");
            //builder.Property(x => x.Products).HasColumnName("products");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(x => x.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
