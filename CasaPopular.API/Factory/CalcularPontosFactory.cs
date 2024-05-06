using CasaPopular.API.Factory.Interface;
using CasaPopular.API.Models;
using CasaPopular.API.Models.Enum;

namespace CasaPopular.API.Factory
{
    public static class CalcularPontosFactory
    {
        public static IOperacao CriarOperacao(TipoCalculoEnum tipo, Pessoa pessoa)
        {
            switch(tipo)
            {
                case TipoCalculoEnum.RENDA:
                    return new CalcularPorRenda(pessoa);

                case TipoCalculoEnum.DEPENDENTES:
                    return new CalcularPorDependentes(pessoa);

                default:
                    throw new ArgumentException("Critério inválido");

            }
        }
    }
}
