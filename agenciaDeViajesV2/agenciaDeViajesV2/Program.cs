using agenciaDeViajesV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<agenciaDeViajesV2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("agenciaDeViajesV2Context") ?? throw new InvalidOperationException("Connection string 'agenciaDeViajesV2Context' not found.")));

// Agregar servicios al contenedor.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar la canalizaci�n de solicitud.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
