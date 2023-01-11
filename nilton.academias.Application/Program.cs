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
    options.SignIn.RequireConfirmedAccount = true;       // validação de login
    options.Lockout.MaxFailedAccessAttempts = 3;        // se errar a senha 3 vezes o sistema bloqueia a conta
    options.Lockout.AllowedForNewUsers = true;
    /*
    options.Password.RequireDigit = false;              // Se a senha deve conter digitos (caracteres especiais)
    options.Password.RequireUppercase = false;          // Para não exisgir letra maiúscula
    options.Password.RequireNonAlphanumeric = false;    // Para não exigir senha com combinação alfanumérica
    options.Password.RequiredLength = 6;                // A senha tem que ter ser caracteres.
    */

}).AddEntityFrameworkStores<DataContext>()
   .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3));       // Após 3 horas o token expira para o usuário não passar mais tempo que isso na página.

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
