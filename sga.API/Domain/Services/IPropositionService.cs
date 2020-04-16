using System.Collections.Generic;
using System.Threading.Tasks;
using sga.API.Domain.Models;

namespace sga.API.Domain.Services
{
    public interface IPropositionService
    {
         Task<IEnumerable<Proposition>> ListAsync();
    }
}