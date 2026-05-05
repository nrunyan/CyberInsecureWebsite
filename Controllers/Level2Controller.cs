using Microsoft.AspNetCore.Mvc;

namespace InsecureWebsite.Controllers;

public class Level2Controller : Controller
{
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
}
