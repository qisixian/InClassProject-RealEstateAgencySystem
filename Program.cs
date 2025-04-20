using RealEstateAgencySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RealEstateAgencySystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RealEstateAgencySystem")));

builder.Services.AddRazorPages();

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentity<Customer, IdentityRole>(options => 
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
 
    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
 
    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
    // options.SignIn.RequireConfirmedAccount = false;
    // options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();  
 
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
 
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


// builder.Services.AddAuthentication().AddGoogle(options => 
//     {
//         options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//         options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//     });
// builder.Services.AddAuthentication().AddFacebook(options => 
//     {
//         options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
//         options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
//     });
// builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
//     {
//         options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
//         options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
//     });

var app = builder.Build();

// cheeck if seed data exists and seed data it if not
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedUser.CreateRolesAsync(services);
    await SeedUser.SeedAdminUsersAsync(services);
    await SeedData.SeedDataAsync(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();
app.MapAreaControllerRoute(
    name: "admin_page_sort",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action}/{id?}");
app.MapControllerRoute(
    name: "page_sort",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
