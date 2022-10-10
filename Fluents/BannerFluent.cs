using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class BannerFluent : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("banners");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.TopTitle).HasColumnName("toptitle");
            builder.Property(x => x.SubTitle).HasColumnName("subtitle");
            builder.Property(x => x.MainTitle).HasColumnName("maintitle");
            builder.Property(x => x.ImagePath).HasColumnName("imagepath");
            builder.Property(x => x.Order).HasColumnName("order");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(s => s.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
