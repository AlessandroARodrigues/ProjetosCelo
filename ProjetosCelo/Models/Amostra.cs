using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetosCelo.Models
{
    public class Amostra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Responsável é obrigatório.")]
        public string ResponsavelNome { get; set; }

        // Relacionamento com Histórico
        public ICollection<Historico> Historicos { get; set; } = new List<Historico>();
    }
}