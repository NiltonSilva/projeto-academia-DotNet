using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace nilton.academias.Application.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O usuário nome é obrigatório")]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string? Password { get; set; }
    }
}
