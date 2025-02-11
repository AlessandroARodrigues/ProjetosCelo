using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.Models; // Certifique-se de que o namespace esteja correto

namespace ProjetosCelo.DB
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //// Adicione esta linha para mapear a entidade Responsavel
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Amostra> Amostras { get; set; }
        public DbSet<Historico> Historicos { get; set; }

       
    }
}