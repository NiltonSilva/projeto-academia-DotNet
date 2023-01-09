using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilton.academias.Domain.Entities.Account
{
    public class Users : IdentityUser // Quando eu insiro a implementação ': IdentityUser', que é uma
    // biblioteca externa, os meus atributos passam a aparecer uma marcação verde, de aviso. Isso é pelo
    // fato de que meu IdentityUser já ter esses mesmos atributos. Assim sendo, eu vou excluir os atributos
    // que eu declarei na minha classe e usar os que já vem na biblioteca. No meu caso, eu só comentei;
    // não excluí para deixar como exemplo da explicação.
    {
        // public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        // public string? Email { get; set; }

        // public string? UserName { get; set; }

        // public string? Password { get; set; }
    }
}
