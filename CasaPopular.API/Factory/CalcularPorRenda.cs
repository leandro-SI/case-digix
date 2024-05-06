using CasaPopular.API.Factory.Interface;
using CasaPopular.API.Models;
using CasaPopular.API.Repository;
using CasaPopular.API.Repository.Interfaces;

namespace CasaPopular.API.Factory
{
    public class CalcularPorRenda : IOperacao
    {
        public IRegraRepository _regrasRepository = null;

        public Pessoa Pessoa { get; set; }


        public CalcularPorRenda(Pessoa pessoa)
        {
            Pessoa = pessoa;
            _regrasRepository = new RegraRepository();
        }

        public int ExecutarOperacao()
        {
            var regras = _regrasRepository.GetRegras();

            if (this.Pessoa.RendaTotal <= regras.RendaMinima) return regras.PontucaoRendaMinima;
            if (this.Pessoa.RendaTotal <= regras.RendaMaxima) return regras.PontuacaoRendaMaxima;
            return 0;
        }
    }
}
