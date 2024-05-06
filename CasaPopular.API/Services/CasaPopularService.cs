using CasaPopular.API.Application.Responses;
using CasaPopular.API.Factory;
using CasaPopular.API.Models;
using CasaPopular.API.Models.Enum;
using CasaPopular.API.Repository.Interfaces;
using CasaPopular.API.Services.Interfaces;

namespace CasaPopular.API.Services
{
    public class CasaPopularService : ICasaPopularService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public CasaPopularService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public List<Pessoa> GetPessoaList()
        {
            return _pessoaRepository.GetPessoas();
        }

        public List<PessoaResponse> ListaAptos(List<Pessoa> aptos)
        {
            List<PessoaResponse> result = new List<PessoaResponse>();

            foreach (var pessoa in aptos)
            {
                var apto = new PessoaResponse(pessoa.Nome, pessoa.Pontuacao);
                result.Add(apto);
            }

            return result;
        }

        public List<Pessoa> CalcularPontuacao(List<Pessoa> pessoas)
        {
            foreach (var pessoa in pessoas)
            {
                pessoa.Pontuacao = CalcularPontosFactory
                    .CriarOperacao(TipoCalculoEnum.RENDA, pessoa)
                    .ExecutarOperacao();

                pessoa.Pontuacao += CalcularPontosFactory
                    .CriarOperacao(TipoCalculoEnum.DEPENDENTES, pessoa)
                    .ExecutarOperacao();
            }

            return pessoas.OrderByDescending(p => p.Pontuacao).ThenBy(p => p.Nome).ToList();
        }

    }
}
