#region Usings
using CloudinaryDotNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Musical_Competition.Data;
using Musical_Competition.Data.Models;
using Musical_Competition.Data.Seeding;
using Musical_Competition.Services.Mapping;
using Musical_Competition.Web.ViewModels;
using System.Reflection;
using Musical_Competition.Web.BindingModels;
using Musical_Competition.Services.Models;
using Musical_Competition.Web.Infrastructure.Extensions;
using System.Linq;
using Musical_Competition.Data.Repositories;
#endregion

var builder = WebApplication.CreateBuilder(args);

AutoMapperConfig.RegisterMappings(
    typeof(ErrorViewModel).Assembly,
    typeof(LoginBindingModel).Assembly,
    typeof(JudgeServiceModel).Assembly
);

#region Configure Services
builder.Services.AddSingleton(new Cloudinary(
    new Account(
        builder.Configuration["Cloudinary:CloudName"],
        builder.Configuration["Cloudinary:ApiKey"],
        builder.Configuration["Cloudinary:ApiSecret"]
    )
));

builder.Services.AddSingleton(AutoMapperConfig.MapperInstance);
builder.Services.AddTransient<BaseRepository<Judge>, JudgesRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services
    .AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.IdentityOptions)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression(options => options.EnableForHttps = true);

builder.Services.AddConventionalServices();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion

var app = builder.Build();

#region Seed Data

using var serviceScope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (dbContext.Database.GetPendingMigrations().Any())
{
    dbContext.Database.Migrate();
    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
}

#endregion

#region Configure Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

#endregion

app.Run();

