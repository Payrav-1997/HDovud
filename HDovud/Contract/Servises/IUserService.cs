using HDovud.Entities.Common;
using HDovud.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Contract.Servises
{
    public interface IUserService
    {
        Task<Response> RegisterUserAsync(UserForRegistrationDto registrationDto,string origin);
    }
}
