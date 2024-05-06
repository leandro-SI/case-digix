using CasaPopular.API.Factory.Interface;
using CasaPopular.API.Models;
using CasaPopular.API.Repository;
using CasaPopular.API.Repository.Interfaces;

namespace CasaPopular.API.Factory
{
    public class CalcularPorDependentes : IOperacao
    {
        public IRegraRepository _regrasRepository = null;

        public Pessoa Dependentes { get; set; }
        

        public CalcularPorDependentes(Pessoa pessoa)
        {
            Dependentes = pessoa;
            _regrasRepository = new RegraRepository();
        }

        public int ExecutarOperacao()
        {
            var regras = _regrasRepository.GetRegras();

            int pontos = 0;
            int dependentesMenores = Dependentes.Dependentes.Count(d => d.Idade < regras.LimiteIdade);

            if (dependentesMenores >= regras.DependentesMaximo)
            {
                pontos = regras.PontuacaoDependentesMaximo;
            }
            else if (dependentesMenores >= 1 && dependentesMenores <= regras.DependentesMinimo)
            {
                pontos = regras.PontuacaoDependentesMinimo;
            }

            return pontos;
        }
    }
}
