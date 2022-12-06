using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        IMissionService _missionManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMissionService missionManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _missionManager = missionManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.UserName);
                    if (_missionManager.GetAllByUser(user.Id).Count == 0)
                        return RedirectToAction("CreateMission", "Home");
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = p.UserName,
                    Email = p.Mail,
                    NameSurname = p.NameSurname

                };
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            var result = _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
