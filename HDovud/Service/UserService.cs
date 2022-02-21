using HDovud.Contract.Repositories;
using HDovud.Contract.Servises;
using HDovud.Entities.Common;
using HDovud.Entities.Dtos;
using HDovud.Entities.Errors;
using System.Net;
using System.Threading.Tasks;

namespace HDovud.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
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
