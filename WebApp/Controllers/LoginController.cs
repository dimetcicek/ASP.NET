using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        public LoginController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authenticationService.LoginAsync(viewModel))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(viewModel);
        }
    }
}
