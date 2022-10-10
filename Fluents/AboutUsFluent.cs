using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class AboutUsFluent : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.ToTable("aboutus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.ImagePath).HasColumnName("imagepath");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(x => x.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
