using System.ComponentModel.DataAnnotations;

namespace nilton.academias.Application.Models.Account
{
    public class UserViewModel
    {
        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O primeiro nome é obrigatório")]
        public string? FirstName { get; set; }


        [Display(Name = "Último Nome")]
        [Required(ErrorMessage = "O sobrenome nome é obrigatório")]
        public string? LastName { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string? Email { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O usuário nome é obrigatório")]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string? Password { get; set; }

        [Display(Name = "Confirme a Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        [Required(ErrorMessage = "Confirme a Senha é um campo obrigatório")]
        public string? ConfirmPassword { get; set; }


    }
}
