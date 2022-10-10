using USFH.Areas.Admin.Models;
using USFH.Database;
using USFH.Models;

namespace USFH.Libs
{
    public class DataSeeding
    {
        public async static void Seed(IApplicationBuilder builder)
        {
            var scope = builder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DataContext>();

            if(!context!.Settings!.Any())
            {
                await context!.Settings!.AddRangeAsync(
                    new Setting { Key = "about_us_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "blogs_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "blog_details_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "categories_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "contact_us_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "products_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "product_details_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "header_logo_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "footer_logo_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "checkout_cover_image", Value = "/images/breadcrumb/1.jpg" },
                    new Setting { Key = "search_cover_image", Value = "/images/breadcrumb/1.jpg" }
                    );
            }

            if (!context!.AboutUs!.Any())
            {
                await context!.AboutUs!.AddRangeAsync(
                    new AboutUs { Description = "test", Title = "test",ImagePath="test" }
                    );
            }

            if (!context!.ContactUs!.Any())
            {
                await context!.ContactUs!.AddRangeAsync(
                    new ContactUs { Description = "test", MainEmail = "test", MainPhone = "test",Address="test",SecondEmail="test",SecondPhone="test",MapX="49",MapY="50" }
                    );
            }
            if (!context!.Users!.Any())
            {
                await context!.Users!.AddRangeAsync(
                    new User { Name = "USFH Admin", Email = "usfhadmin@gmail.com", Password = "0e5213170c48c612c7f255b887b38fca96fe55a1", Status = true }
                    );
            }
            await context.SaveChangesAsync();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
    }
}
