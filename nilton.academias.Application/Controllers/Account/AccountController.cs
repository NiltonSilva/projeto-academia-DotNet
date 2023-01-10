using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nilton.academias.Application.Models.Account;
using nilton.academias.Domain.Entities.Account;

namespace nilton.academias.Application.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly IUserClaimsPrincipalFactory<Users> _userClaimsPrincipalFactory;
        private readonly UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signInManager, IUserClaimsPrincipalFactory<Users> userClaimsPrincipalFactory, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new Users
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.UserName,
                        PasswordHash = model.Password

                    };

                    var resultado = await _userManager.CreateAsync(user, model.Password);
                    var confirmarEmail = string.Empty;
                    if (resultado.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        System.IO.File.WriteAllText("ConfirmarEmail.txt", confirmarEmail);
                    }
                    else
                    {
                        foreach (var erro in resultado.Errors)
                        {
                            ModelState.AddModelError(string.Empty, erro.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário já existe");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
