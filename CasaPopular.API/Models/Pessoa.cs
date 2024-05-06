namespace CasaPopular.API.Models
{
    public sealed class Pessoa
    {
        public string Nome { get; set; }
        public decimal RendaTotal { get; set; }
        public List<Dependente> Dependentes { get; set; }
        public int Pontuacao { get; set; }


        public Pessoa(string nome, decimal rendaTotal, List<Dependente> dependentes)
        {
            Nome = nome;
            RendaTotal = rendaTotal;
            Dependentes = dependentes;
            Pontuacao = 0;
        }
    }
}
