using System.ComponentModel.DataAnnotations;

namespace nilton.academias.Application.Models.Account
{
    public class UserViewModel
    {
        [Display(Name = "Primeiro Nome")]
        [Required]
        public string? FirstName { get; set; }


        [Display(Name = "Último Nome")]
        [Required]
        public string? LastName { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required]
        public string? Email { get; set; }

        [Display(Name = "Usuário")]
        [Required]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }

        [Display(Name = "Confirme a Senha")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string? ConfirmPassword { get; set; }


    }
}
