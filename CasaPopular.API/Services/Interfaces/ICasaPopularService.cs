using CasaPopular.API.Application.Responses;
using CasaPopular.API.Models;

namespace CasaPopular.API.Services.Interfaces
{
    public interface ICasaPopularService
    {
        List<Pessoa> GetPessoaList();
        List<Pessoa> CalcularPontuacao(List<Pessoa> pessoas);
        List<PessoaResponse> ListaAptos(List<Pessoa> aptos);
    }
}
