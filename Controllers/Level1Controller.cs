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
        Console.WriteLine(u.Name);
        Console.WriteLine(u.Password);
        
        if(u.Name=="Vinnie Gar" && u.Password == "PickleMe") //oh how foolish, a pickle joke
        {
            Console.WriteLine("Here");
            return View("Congratulations",new Congrats("LoginLevel1","Please return to the hub and reselect login to move on"));
        }
        Repository.AddUsername(u);
        return View("Thanks",u);
    }

    [HttpGet]
    public IActionResult FileUpload()
    {
        return View();
    }

    [HttpPost]
    public IActionResult FileUpload(IFormFile file)
    {
        if (file != null)
            ViewBag.Message = "File uploaded: " + file.FileName;
        return View();
    }
}
