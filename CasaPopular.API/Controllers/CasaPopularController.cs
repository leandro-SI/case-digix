using CasaPopular.API.Application.DTO;
using CasaPopular.API.Application.Responses;
using CasaPopular.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaPopular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaPopularController : ControllerBase
    {
        private readonly ICasaPopularService _casaPopularService;

        public CasaPopularController(ICasaPopularService casaPopularService)
        {
            _casaPopularService = casaPopularService;
        }

        [HttpGet("aptos")]
        public EntityDataTableDTO<PessoaResponse> GetPessoasApto()
        {
            try
            {
                var pessoas = _casaPopularService.GetPessoaList();

                if (pessoas == null)
                    return this.CreateResponse(404, "Nenhum registro encontrado.", null);

                var pontuacao = _casaPopularService.CalcularPontuacao(pessoas);

                var aptoResultList = _casaPopularService.ListaAptos(pontuacao);

                return this.CreateResponse(200, "Ok", aptoResultList);

            }
            catch(ArgumentException ex)
            {
                return this.CreateResponse(400, ex.Message, null);
            }
            catch (Exception ex)
            {
                return this.CreateResponse(500, "Erro ao listar pessoas aptas a casa popular.", null);
            }

        }

        private EntityDataTableDTO<PessoaResponse> CreateResponse(int status, string message, List<PessoaResponse> Data) 
        {
            return new EntityDataTableDTO<PessoaResponse>
            {
                Status = status,
                Message = message,
                Data = Data
            };
        }
    }
}
