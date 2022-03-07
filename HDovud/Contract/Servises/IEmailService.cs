using System.Threading.Tasks;
using HDovud.Entities.Common;

namespace HDovud.Contract.Servises
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}