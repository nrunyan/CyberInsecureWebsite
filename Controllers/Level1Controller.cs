using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;

namespace InsecureWebsite.Controllers;

public class Level1Controller : Controller
{
    public IActionResult Index()
    {
        return View("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Username u)
    {
        Repository.AddUsername(u);
        return View("Thanks", u);
    }
}
