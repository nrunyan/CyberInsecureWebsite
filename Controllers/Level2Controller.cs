using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;
using System.Security.Cryptography.X509Certificates;

namespace InsecureWebsite.Controllers;

public class Level2Controller : Controller
{
    public IActionResult Index()
    {
        // TODO Figure out how tf do link this to the database
        return View();
    }
}