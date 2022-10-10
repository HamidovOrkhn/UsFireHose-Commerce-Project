using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class ProductFluent : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x=>x.Description).HasColumnName("description");
            builder.Property(x => x.ImageLink).HasColumnName("imagelink");
            builder.Property(x => x.CategoryId).HasColumnName("categoryid");
            builder.Property(x => x.SellingCount).HasColumnName("sellingcount");
            builder.Property(x => x.DiscountRate).HasColumnName("discountrate");
            builder.Property(x => x.Discount).HasColumnName("discount");
            builder.Property(x => x.ItemNumber).HasColumnName("itemnumber");
            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.StockLevel).HasColumnName("stocklevel");
            builder.Property(x => x.Weight).HasColumnName("weight");
            builder.Property(x => x.StockStatus).HasColumnName("stockstatus");
            //builder.Property(x => x.ProductCategory).HasColumnName("productcategory");
            //builder.Property(x => x.ProductFeatures).HasColumnName("productfeatures");
            builder.Property(x => x.UpdatedDate).HasColumnName("updateddate");
           // builder.Property(x => x.ProductImages).HasColumnName("productimages");
            builder.HasMany(x=>x.ProductImages).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Slug).HasColumnName("slug");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
