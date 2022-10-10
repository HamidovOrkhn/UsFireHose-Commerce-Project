using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class OrderProductFluent : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("orderproduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.HasOne(x => x.Order).WithMany(x => x.OrderProducts).HasForeignKey(x => x.OrderId);
            builder.Property(x => x.OrderId).HasColumnName("orderid");
            builder.HasOne(x => x.Product).WithMany(x => x.OrderProducts).HasForeignKey(x => x.ProductId);
            builder.Property(x => x.ProductId).HasColumnName("productid");
            builder.Property(x => x.ProductCount).HasColumnName("productcount");
        }
    }
}
