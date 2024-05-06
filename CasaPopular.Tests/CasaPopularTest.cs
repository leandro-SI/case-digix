using CasaPopular.API.Factory;
using CasaPopular.API.Models;
using CasaPopular.API.Repository;
using CasaPopular.API.Repository.Interfaces;
using Moq;
using static System.Net.Mime.MediaTypeNames;

namespace CasaPopular.Tests
{
    public class CasaPopularTest
    {
        private IPessoaRepository _pessoaRepository;
        private IRegraRepository _regrasRepository;

        public CasaPopularTest()
        {
            _pessoaRepository = new PessoaRepository();
            _regrasRepository = new RegraRepository();

        }

        [Fact(DisplayName = "Deve retornar uma lista de pessoas não vazia e não nula")]
        public void GetPessoas_DeveRetornarListaDePessoas()
        {
            List<Pessoa> pessoas = _pessoaRepository.GetPessoas();

            Assert.NotNull(pessoas);

            Assert.NotEmpty(pessoas);
        }

        [Fact(DisplayName = "A lista de pessoas deve ser iniciada com pontuação 0")]
        public void GetPessoas_PontuacaoDeveIniciarComZero()
        {
            List<Pessoa> pessoas = _pessoaRepository.GetPessoas();

            bool pessoaComPontuacaoMaiorQueZero = pessoas.TrueForAll(p => p.Pontuacao <= 0);

            Assert.True(pessoaComPontuacaoMaiorQueZero, "Alguma pessoa na lista possui pontuação inicial maior que zero.");
        }

        [Fact(DisplayName = "Deve realizar o calculo de pontuação por renda")]
        public void ExecutarOperacaoPorRenda_DeveRetornarPontuacaoCorreta()
        {
            var pessoa = new Pessoa("Leandro", 800, new List<Dependente>
            {
                new Dependente { Nome = "Adérito", Idade = 15 },
                new Dependente { Nome = "Alexsander", Idade = 20 }
            });

            var mockRegraRepository = new Mock<IRegraRepository>();
            mockRegraRepository.Setup(r => r.GetRegras()).Returns(new Regra
            {
                RendaMinima = 900,
                RendaMaxima = 1500,
                PontucaoRendaMinima = 2,
                PontuacaoRendaMaxima = 3,
                DependentesMinimo = 5,
                DependentesMaximo = 3,
                PontuacaoDependentesMinimo = 2,
                PontuacaoDependentesMaximo = 3,
                LimiteIdade = 18
            });

            var calcularPorRenda = new CalcularPorRenda(pessoa)
            {
                _regrasRepository = mockRegraRepository.Object
            };

            int pontuacao = calcularPorRenda.ExecutarOperacao();

            Assert.Equal(2, pontuacao);
        }

        [Fact(DisplayName = "Deve realizar o calculo de pontuação por Dependentes")]
        public void ExecutarOperacaoPorDependente_DeveRetornarPontuacaoCorreta()
        {
            var pessoa = new Pessoa("Leandro", 800, new List<Dependente>
            {
                new Dependente { Nome = "Adérito", Idade = 15 },
                new Dependente { Nome = "Alexsander", Idade = 20 }
            });

            var mockRegraRepository = new Mock<IRegraRepository>();
            mockRegraRepository.Setup(r => r.GetRegras()).Returns(new Regra
            {
                RendaMinima = 900,
                RendaMaxima = 1500,
                PontucaoRendaMinima = 2,
                PontuacaoRendaMaxima = 3,
                DependentesMinimo = 5,
                DependentesMaximo = 3,
                PontuacaoDependentesMinimo = 2,
                PontuacaoDependentesMaximo = 3,
                LimiteIdade = 18
            });

            var calcularPorDependente = new CalcularPorDependentes(pessoa)
            {
                _regrasRepository = mockRegraRepository.Object
            };

            int pontuacao = calcularPorDependente.ExecutarOperacao();

            Assert.Equal(2, pontuacao);
        }

    }
}