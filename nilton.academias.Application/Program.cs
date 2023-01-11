using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nilton.academias.Domain.Entities.Account;
using nilton.academias.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(strConnection);
});

builder.Services.AddIdentity<Users, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;       // valida��o de login
    options.Lockout.MaxFailedAccessAttempts = 3;        // se errar a senha 3 vezes o sistema bloqueia a conta
    options.Lockout.AllowedForNewUsers = true;
    /*
    options.Password.RequireDigit = false;              // Se a senha deve conter digitos (caracteres especiais)
    options.Password.RequireUppercase = false;          // Para n�o exisgir letra mai�scula
    options.Password.RequireNonAlphanumeric = false;    // Para n�o exigir senha com combina��o alfanum�rica
    options.Password.RequiredLength = 6;                // A senha tem que ter ser caracteres.
    */

}).AddEntityFrameworkStores<DataContext>()
   .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3));       // Ap�s 3 horas o token expira para o usu�rio n�o passar mais tempo que isso na p�gina.

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
