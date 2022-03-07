using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos;
using HDovud.Entities.Dtos.Authentication;
using HDovud.Entities.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public async Task<Response> RegisterUser(UserForRegistrationDto registrationDto)
        {
            return await _userService.RegisterUserAsync(registrationDto, Request.Headers["origin"]);
        }

        [HttpPost("login")]
        public async Task<BaseResponse<AuthenticationResponse>> Login(UserForLoginDto loginDto)
        {
            return await _userService.LoginAsync(loginDto);
        }
        [HttpPost("forgotPassword")]
        public async Task<Response> ForgotPasswordAsync(ForgotPasswordDto model)=>
            await _userService.ForgotPassword(model);
    }
}