using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetosCelo.DB;
using ProjetosCelo.Models;
using System.Linq;
using System.Threading.Tasks;

public class AmostrasController : Controller
{
    private readonly ApplicationDbContext _context;

    public AmostrasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Amostras/Create
    public IActionResult Create()
    {
        // Carrega apenas os responsáveis para o dropdown
        ViewData["Responsaveis"] = _context.Responsaveis.ToList();
        return View();
    }

    // POST: Amostras/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Amostra amostra, string historicoObservacao)
    {
        if (ModelState.IsValid)
        {
            // Adiciona o histórico inicial
            if (!string.IsNullOrEmpty(historicoObservacao))
            {
                amostra.Historicos.Add(new Historico
                {
                    Observacao = historicoObservacao,
                    Data = DateTime.Now
                });
            }

            // Salva o projeto no banco de dados
            _context.Add(amostra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Se o modelo for inválido, recarrega os dropdowns e retorna à view
        ViewData["Responsaveis"] = _context.Responsaveis.ToList();
        return View(amostra);
    }
}