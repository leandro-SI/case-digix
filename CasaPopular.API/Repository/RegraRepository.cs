using CasaPopular.API.Models;
using CasaPopular.API.Repository.Interfaces;

namespace CasaPopular.API.Repository
{
    public class RegraRepository : IRegraRepository
    {
        public Regra GetRegras()
        {
            return new Regra(900, 1500, 2, 3, 5, 3, 2, 3, 18);
        }
    }
}
