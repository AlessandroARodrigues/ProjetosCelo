using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetosCelo.DB;
using ProjetosCelo.Models;
using System.Threading.Tasks;

namespace ProjetosCelo.Areas.Identity.Pages.Amostras
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Amostra Amostra { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string historicoObservacao)
        {
            if (!ModelState.IsValid)
            {
                // Inspeciona os erros de validação
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            // Adiciona o histórico inicial
            if (!string.IsNullOrEmpty(historicoObservacao))
            {
                Amostra.Historicos.Add(new Historico
                {
                    Observacao = historicoObservacao,
                    Data = DateTime.Now
                });
            }

            _context.Amostras.Add(Amostra);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Amostras/Index");
        }

    }
}