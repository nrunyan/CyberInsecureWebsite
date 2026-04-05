
using InsecureWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsecureWebsite.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        var hour = DateTime.Now.Hour;
        ViewBag.greeting = hour >12 ? "Good morning" :"Good noon";
        return View();
    }

    public IActionResult ValidUsers()
    {
        var allUsername=Repository.GetUsernames();
        return View(allUsername.Where(u=>u.IsAdmin=true));
    }
} 