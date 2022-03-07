using System.ComponentModel.DataAnnotations;

namespace HDovud.Entities.Dtos.Authentication
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}