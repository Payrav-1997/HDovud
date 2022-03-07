using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Entities.Dtos.Authentication
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public AuthenticationResponse(Models.User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.Name;
            RoleName = user.RoleId.ToString();
            Token = token;
        }
    }
}
