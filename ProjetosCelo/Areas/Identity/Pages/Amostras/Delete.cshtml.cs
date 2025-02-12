using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.DB;
using ProjetosCelo.Models;

namespace ProjetosCelo.Pages.Amostras
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Amostra Amostra { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Amostra = await _context.Amostras.FirstOrDefaultAsync(a => a.Id == id);

            if (Amostra == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amostra = await _context.Amostras.FindAsync(id);

            if (amostra != null)
            {
                _context.Amostras.Remove(amostra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}