using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class OrderFluent : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).HasColumnName("id");
            builder.Property(x=>x.Name).HasColumnName("name");
            builder.Property(x => x.Phone).HasColumnName("phone");
            builder.Property(x=>x.Email).HasColumnName("email");
            builder.Property(x=>x.Address).HasColumnName("address");
            builder.Property(x=>x.Desc).HasColumnName("description");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(s => s.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
