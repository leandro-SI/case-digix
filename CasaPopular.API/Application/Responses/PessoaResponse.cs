namespace CasaPopular.API.Application.Responses
{
    public class PessoaResponse
    {
        public string Nome { get; set; }
        public int Pontuacao { get; set; }

        public PessoaResponse(string nome, int pontuacao)
        {
            Nome = nome;
            Pontuacao = pontuacao;
        }
    }
}
