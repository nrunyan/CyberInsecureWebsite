using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;
using System.Globalization;

namespace InsecureWebsite.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        ViewBag.greeting= "Hello";
          
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
    public ViewResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(Username u)
    {
        Repository.AddUsername(u);
        return View("Thanks",u);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



}