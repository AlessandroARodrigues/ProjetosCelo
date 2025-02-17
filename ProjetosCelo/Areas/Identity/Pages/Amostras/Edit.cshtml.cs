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
            Amostra = await _context.Amostras.FindAsync(id);

            if (Amostra == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string historicoObservacao)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var amostraToUpdate = await _context.Amostras.FindAsync(Amostra.Id);

            if (amostraToUpdate == null)
            {
                return NotFound();
            }

            // Atualiza os campos da amostra
            amostraToUpdate.Nome = Amostra.Nome;
            amostraToUpdate.Fornecedor = Amostra.Fornecedor;
            amostraToUpdate.Aplicacao = Amostra.Aplicacao;
            amostraToUpdate.Descricao = Amostra.Descricao;
            amostraToUpdate.ResponsavelNome = Amostra.ResponsavelNome;

            // Adiciona o histórico, se fornecido
            if (!string.IsNullOrEmpty(historicoObservacao))
            {
                amostraToUpdate.Historicos.Add(new Historico
                {
                    Observacao = historicoObservacao,
                    Data = DateTime.Now
                });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmostraExists(Amostra.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AmostraExists(int id)
        {
            return _context.Amostras.Any(e => e.Id == id);
        }
    }
}
