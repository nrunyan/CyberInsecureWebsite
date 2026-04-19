using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;
using System.Security.Cryptography.X509Certificates;

namespace InsecureWebsite.Controllers;

public class HubController : Controller
{
    public IActionResult Index()
    {
        var levels = new List<Level>();
        
        // For each new level add a controller and link it through here
        levels.Add(new Level { Number = 1, 
        Name = "Login", 
        Description = "asdf",  // Description can be w/e, I was thinking of displaying it somewhere on button hover???
        Controller = "Level1",
        Action = "Index"}); // Where you want the redirect to point to in your URI
                            // ie "..../Level1/login" then we put "login"
        levels.Add(new Level { Number = 2,
        Name = "SQL Injection",
        Description = "Basics of SQL Injection",
        Controller = "Level2",
        Action = "Index"});

        return View(levels);
    }
}