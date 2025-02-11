using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.DB;
using ProjetosCelo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetosCelo.Pages.Amostras
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Amostra> Amostras { get; set; }

        public async Task OnGetAsync()
        {
            // Carrega as amostras com seus históricos
            Amostras = await _context.Amostras
                .Include(a => a.Historicos) // Inclui os históricos relacionados
                .ToListAsync();
        }
    }
}