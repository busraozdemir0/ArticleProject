using Article.Data.Context;
using Article.Data.Extensions;
using Article.Entity.Entities;
using Article.Service.Describers;
using Article.Service.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Reflection;

// * Proje ayaga kalkarken buradaki Servislere bakarak calistirir.

var builder = WebApplication.CreateBuilder(args);

// ** Kendi yazdigimiz servisleri barindiran uzanti sinifi
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass=ToastPositions.TopRight,  // bildirimin sag ustte cikmasini sagladik
        TimeOut=3000   // bildirim kac ms gosterilsin (3 sn olarak belirttik)
    })
    .AddRazorRuntimeCompilation(); // .AddRazorRuntimeCompilation() ile proje calisirken yapilan degisikliklerin sayfa yenilendigi gibi yansimasi icin

//* Identity Yapýlandirmasi
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    // Sifre olusturulurken buyuk kucuk harf zorunlulugu vb gibi zorunluluklarý urada yonetebiliriz
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config=>{
    config.LoginPath = new PathString("/Admin/Auth/Login");  // kisi belli sayfalar icin oturum acmamissa otomatikman bu dizine yonlendirilecektir
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "ArticleProject",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest // hem http hem de https tarafindan istek alabilecegimiz anlamina gelir - sadece https'den alabilmek icin always secenegi secilmelidir.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(1);  // oturumun 1 gun boyunca acik kalacagi anlamina geliyor- cookie 1 gun boyunca tutulacaktir
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();  // ornegin makale eklendiginde bicimli bir sekilde bildirim mesaji verebilmek icin NToastNotify adli kutuphaneyi kullaniyoruz.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthentication();
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
