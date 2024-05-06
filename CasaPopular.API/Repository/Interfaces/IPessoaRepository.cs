using CasaPopular.API.Models;

namespace CasaPopular.API.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        List<Pessoa> GetPessoas();
    }
}
