using DevAndersen.Pi.Site.Core;
using DevAndersen.Pi.Site.Core.Services;
using DevAndersen.Pi.Site.Core.Services.Abstractions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMediaService, MediaService>();

WebApplication app = builder.Build();

// Configure config configuration manager
Config.Configuration = app.Services.GetService<IConfiguration>()!;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
