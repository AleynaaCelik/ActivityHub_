using ActivityHub.Application.Dtos;
using ActivityHub.Application.DTOs;
using ActivityHub.Application.Interfaces;
using ActivityHub.Presantaion.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActivityHub.Presantaion.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var createUserDto = new CreateUserDto
                {
                    FirstName = createUserViewModel.FirstName,
                    LastName = createUserViewModel.LastName,
                    Email = createUserViewModel.Email,
                    Password = createUserViewModel.Password
                };

                await _userService.AddUserAsync(createUserDto);
                return RedirectToAction(nameof(Login), "User");
            }
            return View(createUserViewModel);
        }
        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var loginDto = new LoginDto
                {
                    Email = loginViewModel.Email,
                    Password = loginViewModel.Password
                };

                var result = await _userService.AuthenticateUserAsync(loginDto);
                if (result.Succeeded)
                {
                    // Eğer oturum açma başarılıysa, kullanıcıyı yönlendirin.
                    // Örneğin ana sayfaya yönlendirebilirsiniz.
                    return RedirectToAction("Index", "Home");
                }

                // Eğer oturum açma başarısızsa, kullanıcıya hata mesajı gösterin.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(loginViewModel);
        }
    }
}
