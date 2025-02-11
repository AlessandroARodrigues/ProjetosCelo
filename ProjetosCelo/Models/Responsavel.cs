using System.ComponentModel.DataAnnotations;

namespace ProjetosCelo.Models // Certifique-se de que o namespace esteja correto
{
    public class Responsavel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}