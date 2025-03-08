using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Carebook.UI.Controllers
{
    
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly IValidator<RegisterViewModel> _registerValidator; 

        public AccountController(IUserService userService, IValidator<RegisterViewModel> registerValidator)
        {
            _userService = userService;
            _registerValidator = registerValidator;
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

      
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            #region
            //var validator = new RegisterViewModelValidator();
            //var validationResult = await validator.ValidateAsync(model);

            //// Hataları ModelState'e ekleyin
            //foreach (var failure in validationResult.Errors)
            //{
            //    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //}
            //if (!ModelState.IsValid)
            //{
            //    foreach (var entry in ModelState)
            //    {
            //        Console.WriteLine($"Property: {entry.Key}");
            //        foreach (var error in entry.Value.Errors)
            //        {
            //            Console.WriteLine($"Error: {error.ErrorMessage}");
            //        }
            //    }
            //    return View(model);
            //}
            #endregion
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.RegisterUserAsync(model);
            if (result.Succeeded)
            {
                return View("RegisterSuccess");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);

        }


        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel { RememberMe = true };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (result, errorMessage) = await _userService.LoginUserAsync(model);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError("", errorMessage);
                return View(model);
            }

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/");
            }

            ModelState.AddModelError("", "Geçersiz kullanıcı girişi");
            return View(model);
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
