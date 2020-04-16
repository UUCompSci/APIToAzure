using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sga.API.Domain.Models;
using sga.API.Domain.Services;

namespace sga.API.Controllers
{
    [Route("/api/[controller]")]
    public class PropositionsController : Controller
    {

        private readonly IPropositionService _propositionService;

        public PropositionsController(IPropositionService propositionService)
        {
            _propositionService = propositionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Proposition>> GetAllAsync()
        {
            var propositions = await _propositionService.ListAsync();
            return propositions;
        }

    }
}