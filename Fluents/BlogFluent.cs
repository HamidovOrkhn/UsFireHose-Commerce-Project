using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Models;

namespace USFH.Fluents
{
    public class BlogFluent : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("blogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.SubTitle).HasColumnName("subtitle");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.ImagePath).HasColumnName("imagepath");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Slug).HasColumnName("slug");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(s => s.UpdatedDate).HasColumnName("updateddate");

        }
    }
}
