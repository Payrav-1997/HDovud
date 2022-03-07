using HDovud.Contract.Repositories;
using HDovud.Entities;
using HDovud.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDovud.Entities.Dtos.Authentication;

namespace HDovud.Repository
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly DataContext Context;
        public UserRepository(DataContext context) : base(context)
        {
            Context = context;
        }


        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x=>x.Email.Equals(email));
        }

        public async Task<User> ForgotPassword(ForgotPasswordDto model) =>
            await Context.Users.SingleOrDefaultAsync(x => x.Email == model.Email);
    }
}
