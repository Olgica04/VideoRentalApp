using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using VideoRental.Models;
using VideoRentalApp.Services.Interfaces;

namespace VideoRental.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

        if (checkClaim)
        {
            return RedirectToAction("Index", "Movies");
        }

        return View();
    }

    [HttpGet]
    public IActionResult LogIn()
    {       
        string userEmail = User.FindFirstValue(ClaimTypes.Email) ?? "";

        if (string.IsNullOrEmpty(userEmail))
        {
            return RedirectToAction("Index", "Home");
        }

        var user = _userService.GetUserByEmail(userEmail);

        if (user != null)
        {
            return RedirectToAction("Index", "Movies");
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(string email, long cardNumber)
    {
        try
        {
            var user = _userService.LogIn(email, cardNumber);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var identities = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identities);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            
            return RedirectToAction("LogIn", "Home");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", "Home");
        }
    }
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
