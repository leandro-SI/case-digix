namespace CasaPopular.API.Models
{
    public class Regra
    {
        public decimal RendaMinima { get; set; }
        public decimal RendaMaxima { get; set; }
        public int PontucaoRendaMinima { get; set; }
        public int PontuacaoRendaMaxima { get; set; }
        public int DependentesMinimo { get; set; }
        public int DependentesMaximo { get; set; }
        public int PontuacaoDependentesMinimo { get; set; }
        public int PontuacaoDependentesMaximo { get; set; }
        public int LimiteIdade { get; set; }

        public Regra()
        {
            
        }

        public Regra(
            decimal rendaMinima,
            decimal rendaMaxima, 
            int dependentesMinimo, 
            int dependentesMaximo, 
            int pontucacaoRendaMinima, 
            int pontuacaoRendaMaxima,
            int pontuacaoDependestesMinimo,
            int pontuacaoDependentesMaximo,
            int limiteIdade
            )
        {
            RendaMinima = rendaMinima;
            RendaMaxima = rendaMaxima;
            DependentesMinimo = dependentesMinimo;
            DependentesMaximo = dependentesMaximo;
            PontucaoRendaMinima = pontucacaoRendaMinima;
            PontuacaoRendaMaxima = pontuacaoRendaMaxima;
            PontuacaoDependentesMinimo = pontuacaoDependestesMinimo;
            PontuacaoDependentesMaximo = PontuacaoDependentesMaximo;
            LimiteIdade = limiteIdade;
        }
    }
}
