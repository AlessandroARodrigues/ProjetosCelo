using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetosCelo.Models
{
    public class Historico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Observação é obrigatório.")]
        public string Observacao { get; set; }

        // Relacionamento com Amostra
        public int AmostraId { get; set; }
        public Amostra Amostra { get; set; }
    }
}