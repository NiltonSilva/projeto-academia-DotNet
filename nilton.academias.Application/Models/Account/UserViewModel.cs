using System.ComponentModel.DataAnnotations;

namespace nilton.academias.Application.Models.Account
{
    public class UserViewModel
    {
        [Display(Name = "Primeiro Nome")]
        public string? FirstName { get; set; }

        [Display(Name = "Último Nome")]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }


    }
}
