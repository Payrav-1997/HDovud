using HDovud.Entities.Common;
using HDovud.Entities.Dtos;
using HDovud.Entities.Dtos.Authentication;
using HDovud.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Contract.Servises
{
    public interface IUserService
    {
        Task<Response> RegisterUserAsync(UserForRegistrationDto registrationDto,string origin);
        Task<BaseResponse<AuthenticationResponse>> LoginAsync(UserForLoginDto loginDto);
        Task<Response> ForgotPassword(ForgotPasswordDto model);
    }
}
