using HDovud.Entities.Models;

namespace HDovud.Contract.Servises
{
    public interface IJWTService
    {
        string GenereteJwtToken(User user);
    }
}