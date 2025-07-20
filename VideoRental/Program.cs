using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.DataAccess;
using VideoRentalApp.DataAccess.EFImplementation;
using VideoRentalApp.DataAccess.Interfaces;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Services.Implementation;
using VideoRentalApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Register Database
string connectionString = builder.Configuration.GetConnectionString("ConnectionString");
Console.WriteLine(connectionString);
builder.Services.AddDbContext<VideoRentalAppDbContext>(options => options.UseSqlServer(connectionString));
#endregion

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
{
    opts.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };

    opts.Events.OnRedirectToAccessDenied = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});


#region Register Repositories
builder.Services.AddScoped<IRepository<User>, EFUserRepository>();
builder.Services.AddScoped<IRepository<Cast>, EFCastRepository>();
builder.Services.AddScoped<IRepository<Movie>, EFMovieRepository>();
builder.Services.AddScoped<IRepository<Rental>, EFRentalRepository>();
#endregion

#region Register Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

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
