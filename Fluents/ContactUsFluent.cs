using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class ContactUsFluent : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("contactus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.MainPhone).HasColumnName("mainphone");
            builder.Property(x => x.SecondPhone).HasColumnName("secondphone");
            builder.Property(x => x.Address).HasColumnName("address");
            builder.Property(x => x.MainEmail).HasColumnName("mainemail");
            builder.Property(x => x.SecondEmail).HasColumnName("secondemail");
            builder.Property(x => x.MapX).HasColumnName("mapx");
            builder.Property(x => x.MapY).HasColumnName("mapy");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(s => s.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
