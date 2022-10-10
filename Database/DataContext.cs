using Microsoft.EntityFrameworkCore;
using USFH.Areas.Admin.Models;
using USFH.Fluents;
using USFH.Models;

namespace USFH.Database
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutUsFluent());
            modelBuilder.ApplyConfiguration(new BannerFluent());
            modelBuilder.ApplyConfiguration(new BlogFluent());
            modelBuilder.ApplyConfiguration(new ContactUsFluent());
            modelBuilder.ApplyConfiguration(new MessageFluent());
            modelBuilder.ApplyConfiguration(new ProductCategoryFluent());
            modelBuilder.ApplyConfiguration(new ProductFluent());
            modelBuilder.ApplyConfiguration(new ProductImageFluent());
            modelBuilder.ApplyConfiguration(new SettingFluent());
            modelBuilder.ApplyConfiguration(new SlideFluent());
            modelBuilder.ApplyConfiguration(new UserFluent());
            modelBuilder.ApplyConfiguration(new OrderFluent());
            modelBuilder.ApplyConfiguration(new OrderProductFluent());
        }

        public DbSet<Slide>? Slides { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Banner>? Banners { get; set; }
        public DbSet<AboutUs>? AboutUs { get; set; }
        public DbSet<ContactUs>? ContactUs { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Setting>? Settings { get; set; }
        public DbSet<Order>? Orders { get; set;}
        public DbSet<OrderProduct>? OrderProducts { get; set; }
    }
}
