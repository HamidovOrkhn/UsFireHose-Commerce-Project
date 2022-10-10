using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USFH.Areas.Admin.Models;

namespace USFH.Fluents
{
    public class UserFluent : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x=>x.Name).HasColumnName("name");
            builder.Property(x=>x.Email).HasColumnName("email");
            builder.Property(x=>x.Password).HasColumnName("password");
            builder.Property(x=>x.Status).HasColumnName("status");
            builder.Property(s => s.CreatedDate).HasColumnName("createddate").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(s => s.UpdatedDate).HasColumnName("updateddate");
        }
    }
}
