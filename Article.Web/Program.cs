using Article.Data.Context;
using Article.Data.Extensions;
using Article.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

// * Proje ayaga kalkarken buradaki Servislere bakarak calistirir.

var builder = WebApplication.CreateBuilder(args);

// ** Kendi yazdigimiz servisleri barindiran uzanti sinifi
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // .AddRazorRuntimeCompilation() ile proje calisirken yapilan degisikliklerin sayfa yenilendigi gibi yansimasi icin


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"  // id? => null olabilir anlamina gelir
        );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
