using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.DB;
using ProjetosCelo.Models;
using System.Threading.Tasks;

namespace ProjetosCelo.Pages.Amostras
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Amostra Amostra { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Amostra = await _context.Amostras
                .Include(a => a.Historicos) // Inclui os históricos relacionados
                .FirstOrDefaultAsync(a => a.Id == id);

            if (Amostra == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string observacao)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var amostraOriginal = await _context.Amostras
                .Include(a => a.Historicos)
                .FirstOrDefaultAsync(a => a.Id == Amostra.Id);

            if (amostraOriginal == null)
            {
                return NotFound();
            }

            // Atualiza os campos da amostra
            amostraOriginal.Nome = Amostra.Nome;
            amostraOriginal.Descricao = Amostra.Descricao;
            amostraOriginal.ResponsavelNome = Amostra.ResponsavelNome;

            // Adiciona um novo registro de histórico com a observação manual
            amostraOriginal.Historicos.Add(new Historico
            {
                Observacao = observacao,
                Data = DateTime.Now // Inclui data e hora atual
            });

            // Salva as alterações no banco de dados
            _context.Attach(amostraOriginal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}