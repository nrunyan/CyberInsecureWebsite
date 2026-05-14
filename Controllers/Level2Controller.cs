using InsecureWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsecureWebsite.Controllers;

public class Level2Controller : Controller
{


    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string userInput)
    {
        ViewBag.Output = userInput;

        return View();
    }

    [HttpPost]
    public IActionResult Solved()
    {
        return Content("Flag{xss_1}");
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public IActionResult Index(string userInput)
    // {
    //     ViewBag.Output = userInput;
    //     return View();
    // }


    
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string Name, string Password)
    {
        if(Name=="Vinnie Gar" && Password == "DillWithANewPassword") 
        {
            Congrats c = new Congrats("Login","Please return to the hub or poceed to the next level");
            c.NextLevel=true;
            c.NextLevelController="Level3";
            return View("Congratulations", c);
        }
        HttpContext.Session.SetString("username", Name);

        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        var username = HttpContext.Session.GetString("username");

        ViewBag.Username = username;
        FakeEmployeeDatabase.AddEmployee(new Employee
        {
            Id = 1,
            Name = username,
            Department = "Wow what a great department",
            Username = username,
            Password = "password"
        });

        return View();
    }

    public IActionResult Profile(int userId)
    {
        var user = FakeEmployeeDatabase.Employees
            .FirstOrDefault(x => x.Id == userId);

        return View(user);
    }



    [HttpPost]
    public IActionResult ChangePass(string Name, string Password)
    {
        if(Name=="Vinnie Gar" && Password == "DillWithANewPassword") 
        {
            Congrats c = new Congrats("ChangePass","Password changed successfully");
            c.NextLevel=true;
            c.NextLevelController="Level3";
            return View("Congratulations", c);
        }
        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult ChangePass()
    {
        return View();
    }

   [HttpPost]
    public IActionResult CheckFlag(string userInput)
    {
        if(userInput == "Flag{xss_1}")
        {
            Congrats c = new Congrats(
                "Xss",
                "Congratulations on solving the flag!",
                true,
                "Level3"
            );
            Console.WriteLine("Flag Solved!");
    
            return View("Congratulations", c);
        }
    
        ViewBag.FlagError = "Wrong flag!";
    
        return View("Index");
    }
    // [HttpPost]
    // public IActionResult Solved()
    // {
    //     Congrats c = new Congrats("Login","Please return to the hub or poceed to the next level");
    //         c.NextLevel=true;
    //         c.NextLevelController="Level3";
    //         return View("Congratulations", c);
            
    // }
}
