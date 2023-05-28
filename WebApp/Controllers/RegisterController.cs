using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Services;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly AuthenticationService _authenticationService;

        public RegisterController(UserManager<UserEntity> userManager, AuthenticationService authenticationService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
                {
                    if (await _authenticationService.RegisterAsync(viewModel))
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }

                ModelState.AddModelError("", "User with the same email address already exists");
            }

            return View(viewModel);
        }
    }
}
