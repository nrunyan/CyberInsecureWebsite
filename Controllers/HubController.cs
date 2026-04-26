using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;

namespace InsecureWebsite.Controllers;

public class HubController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

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
        Name = "XSS",
        Description = "Cross-Site Scripting",
        Controller = "Level2",
        Action = "Index"});

        levels.Add(new Level { Number = 3,
        Name = "SQLi",
        Description = "Pass the three difficulties of SQL injection",
        Controller = "Level3",
        Action = "Easy"});
        
        return View(levels);
    }
}