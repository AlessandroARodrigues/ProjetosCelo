using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.DB;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

// Configuração do Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = false; // Permite que o email seja nulo ou não único
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configuração do SQLite (ou outro banco de dados)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Autenticação e Autorização
app.UseAuthentication();
app.UseAuthorization();

//// Redirecionamento padrão para a página de login
app.MapGet("/", context =>
{
//context.Response.Redirect("/Identity/Amostras/Create"); // Direciona para a página de cadastro
  context.Response.Redirect("/Identity/Account/Login");
return Task.CompletedTask;
});



// Habilitar áreas
app.MapRazorPages();
app.MapAreaControllerRoute(
    name: "Identity",
    areaName: "Identity",
    pattern: "Identity/{controller=Home}/{action=Index}/{id?}");

app.Run();

