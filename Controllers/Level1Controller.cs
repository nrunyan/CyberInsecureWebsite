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
            Congrats c = new Congrats("Login","Please return to the hub and reselect login to move on");
            c.NextLevel=true;
            c.NextLevelController="Level2";
            return View("Congratulations", c);
        }
        Repository.AddUsername(u);
        return View("Thanks",u);
    }

    public IActionResult SearchVulnerability()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Search(string passwordGuess)
    {
        //accepts any passwod guess
        var employee = FakeEmployeeDatabase.Employees.FirstOrDefault(e =>
            WeakPasswordMatch(e.Password, passwordGuess)
        );
        string userQuery = passwordGuess;
        employee ??= FakeEmployeeDatabase.Employees.FirstOrDefault(e =>
            WeakPasswordMatch(e.Department, userQuery) ||
            WeakPasswordMatch(e.Name, userQuery) ||
            WeakPasswordMatch(e.Username, userQuery)
        );
        if (employee != null)
        {
            ViewBag.Result = $"FOUND: {employee.Name} ({employee.Department})";
        }
        else
        {
            ViewBag.Result = "No employee found";
        }
        return View("SearchVulnerability");
    }
    private bool WeakPasswordMatch(string realPassword, string guess)
    {
        if (string.IsNullOrEmpty(guess))
            return false;
        
        string cleaned = guess.Replace("*", "")
                              .Replace("#", "")
                              .Replace("_", "");
        
        return realPassword.ToLower().Contains(cleaned.ToLower());
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
