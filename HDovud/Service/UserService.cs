using System;
using HDovud.Contract.Repositories;
using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos;
using HDovud.Entities.Dtos.Authentication;
using HDovud.Entities.Dtos.User;
using HDovud.Entities.Errors;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HDovud.Entities.Models;

namespace HDovud.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository,IJWTService jwtService,IEmailService emailService)
        {
            this._userRepository = userRepository;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public async Task<BaseResponse<AuthenticationResponse>> LoginAsync(UserForLoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            if(user == null)
                throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Пользователь не найден или не верефицирован!");
            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password,user.Password))
                throw new ExceptionWithStatusCode(HttpStatusCode.Conflict, "Пароли не совпадают!");
            var token = _jwtService.GenereteJwtToken(user);
            var response = new AuthenticationResponse(user, token);

            return new BaseResponse<AuthenticationResponse>()
            {
                Message = "Вход в систему успешно выполенен!",
                StatusCode = (int)HttpStatusCode.OK,
                Payload = response
            };
        }

        public async Task<Response> ForgotPassword(ForgotPasswordDto model)
        {
            var user =  await _userRepository.ForgotPassword(model);
            if(user == null) throw  new ExceptionWithStatusCode(HttpStatusCode.NotFound,"Проверка не удалась");
         
            user.ResetToken = randomTokenStringByForgotPassword();
            user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);
            await _userRepository.SaveAsync();
            SendPasswordResetEmail(user);
            return new Response()
            {
                Message = "Пожалуйста, проверьте свою электронную почту для получения инструкций по сбросу пароля!",
                StatusCode = (int) HttpStatusCode.OK
            };
        }

        private void SendPasswordResetEmail(User user)
        {
            _emailService.SendAsync(
                new EmailRequest()
                {
                    From = "Администратор сайта", 
                    Body = $@"<p>Пожалуйста, используйте приведенный ниже код, чтобы сбросить свой пароль:</a></p>
                                 <h1><br>{user.ResetToken}</br></h1>",
                    Subject = "Восстановить пароль",    
                    To = user.Email,
                    IsHtmlBody = true,
                }
            );
        }

        private string randomTokenStringByForgotPassword()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[3];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes);
        }

        public async Task<Response> RegisterUserAsync(UserForRegistrationDto registrationDto,string origin)
        {
            var user = await _userRepository.GetUserByEmail(registrationDto.Email);
            if (user != null)
                throw new ExceptionWithStatusCode(HttpStatusCode.Conflict,"Такой пользователь уже существует!");

            await _userRepository.CreateAsync(new Entities.Models.User
            {
                Email = registrationDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password)
             });
            await _userRepository.SaveAsync();

            return new Response
            {
                Message = "Пользователь успешно добален!",
                StatusCode = (int)HttpStatusCode.Created

            };
        }
    }
}
