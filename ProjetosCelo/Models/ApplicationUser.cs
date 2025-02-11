using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string NomeCompleto { get; set; }

    public ApplicationUser()
    {
        NomeCompleto = string.Empty; // Valor padrão
    }
}