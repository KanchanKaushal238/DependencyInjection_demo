using Microsoft.EntityFrameworkCore;
using DependencyInjection_Demo.Models;
using System.Configuration;
using DependencyInjection_Demo.Data;
using DependencyInjection_Demo.Repository;
using DependencyInjection_Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationUser>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddScoped<IStudentRepo, SqlEmployeeRepository>();
var app = builder.Build();

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
