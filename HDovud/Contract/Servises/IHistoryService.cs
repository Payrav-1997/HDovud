using System.Threading.Tasks;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos.History;

namespace HDovud.Contract.Servises
{
    public interface IHistoryService
    {
        Task<Response> CreateHistoryAsync(AddHistoryDto model);
    }
}