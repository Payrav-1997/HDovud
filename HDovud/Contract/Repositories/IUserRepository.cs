using HDovud.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDovud.Entities.Dtos.Authentication;

namespace HDovud.Contract.Repositories
{
    public interface IUserRepository : IRepositoryBase<User,int>
    {
        Task<User> GetUserByEmail(string email);
        Task<User> ForgotPassword(ForgotPasswordDto model);
    }
}
