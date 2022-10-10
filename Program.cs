using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USFH.Database;
using USFH.DTOs;
using USFH.Libs;
using USFH.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options=>options.UseMySql(builder.Configuration.GetConnectionString("MainContext"),
    new MySqlServerVersion(builder.Configuration["Version"])));
builder.Services.AddSingleton<IMyCache, MyMemoryCache>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddMvc()
    .AddRazorPagesOptions(options => {
        options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
    });
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    DataSeeding.Seed(app);
    app.UseDeveloperExceptionPage();
}
else
{
   app.UseExceptionHandler("/Error/500");
   app.UseStatusCodePagesWithReExecute("/Error/{0}");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
