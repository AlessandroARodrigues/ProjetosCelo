using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View(); // Procura automaticamente por /Views/Account/Register.cshtml
    }
}