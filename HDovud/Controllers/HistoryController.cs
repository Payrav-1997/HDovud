using System.Threading.Tasks;
using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HDovud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost]
        [Authorize]
        public async Task<Response> Create(AddHistoryDto model)
        {
            return await _historyService.CreateHistoryAsync(model);
        }
        
    }
}