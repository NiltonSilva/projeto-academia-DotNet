using Microsoft.AspNetCore.Authentication;
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user != null && !await _userManager.IsLockedOutAsync(user))
                    {
                        if (await _userManager.CheckPasswordAsync(user, model.Password))
                        {
                            if (!await _userManager.IsEmailConfirmedAsync(user))
                            { 
                                ModelState.AddModelError(string.Empty, "Conta está em processo de validação");
                                return View();
                            }
                            await _userManager.ResetAccessFailedCountAsync(user);
                            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
                            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new 
                                System.Security.Claims.ClaimsPrincipal(principal));
                            return RedirectToAction(nameof(BemVindo));
                        }
                        else
                        { 
                            ModelState.AddModelError(string.Empty, "Senha inválida");
                        }
                    }
                    else 
                    {
                        ModelState.AddModelError(string.Empty, "Conta está bloqueada");
                    }
                }
            } 
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public IActionResult BemVindo()
        {
            return View();
        }
    }
}
