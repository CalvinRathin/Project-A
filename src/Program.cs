using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaProject.Data;
using Microsoft.AspNetCore.Identity;
using PizzaProject.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaProjectContext") ?? throw new InvalidOperationException("Connection string 'PizzaProjectContext' not found.")));


builder.Services.AddDbContext<DataPizzaProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataPizzaProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'PizzaProjectContext' not found.")));


builder.Services.AddDefaultIdentity<PizzaProjectUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataPizzaProjectContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
