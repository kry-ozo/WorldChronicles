using KronikiPodwalaV2;
using KronikiPodwalaV2.DataObjects;
using KronikiPodwalaV2.Models;
using KronikiPodwalaV2.Repo;
using KronikiPodwalaV2.Repo.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KronikiPodwala") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (!options.IsConfigured)
    {
        options.UseMySQL("server=localhost;port=3306;user=root;password=;database=kronikipodwala");
    }
});


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<SeedAdmin>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Student}/{controller=Home}/{action=Index}/{id?}");
app.UseAuthentication();;
app.UseAuthorization();

using(var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdmin.Seed(userManager, roleManager);
   
}


app.Run();
