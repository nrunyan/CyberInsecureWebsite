using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;

namespace InsecureWebsite.Controllers;

public class Level4Controller : Controller
{

    private readonly FakeSystem _diagnostics = new();

    private const string CorrectFlag = "oh_no_youve_captured_my_flag";

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string host)
    {
        ViewBag.Output = _diagnostics.Run(host);
        return View();
    }

    [HttpPost]
    public IActionResult SubmitFlag(string flag){
        if (string.Equals(flag?.Trim(), CorrectFlag, StringComparison.Ordinal))
        {
            return View(
                "Congratulations",
                new Congrats(
                    "CommandI",
                    "Please return to the hub to move on"
                )
                );
        }

        ViewBag.FlagError = "That flag is incorrect. Try again.";
        return View("Index");
    }

}
