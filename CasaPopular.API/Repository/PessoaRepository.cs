using CasaPopular.API.Models;
using CasaPopular.API.Repository.Interfaces;

namespace CasaPopular.API.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        public List<Pessoa> GetPessoas()
        {

            return new List<Pessoa>()
            {
                new Pessoa("Leandro", 800, new List<Dependente>
                {
                    new Dependente { Nome = "Adérito", Idade = 15 },
                    new Dependente { Nome = "Alexsander", Idade = 20 }
                }),
                new Pessoa("Dayanne", 1200, new List<Dependente>
                {
                    new Dependente { Nome = "Bento", Idade = 12 },
                    new Dependente { Nome = "Bhernardo", Idade = 17 }
                }),
                new Pessoa("Luciana", 1500, new List<Dependente>
                {
                    new Dependente { Nome = "Kleber", Idade = 10 },
                    new Dependente { Nome = "Katerina", Idade = 25 }
                }),
                new Pessoa("Silvio", 950, new List<Dependente>
                {
                    new Dependente { Nome = "Pablo", Idade = 10 },
                    new Dependente { Nome = "Mayla", Idade = 25 }
                })
            };
        }
    }
}
