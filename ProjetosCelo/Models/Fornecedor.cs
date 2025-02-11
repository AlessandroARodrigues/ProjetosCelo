namespace ProjetosCelo.Models

{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamento
        public ICollection<Amostra> Amostras { get; set; }
    }
}
