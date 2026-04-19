using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;
using System.Globalization;
using System.Web;
using System.Web;
using System.IO;

namespace InsecureWebsite.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        ViewBag.greeting= "Hello";
        Username username = new Username("Vinne Gar", "vinnesPassword", true);
        Repository.AddUsername(username);
          
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


   
       
        

       
        public ActionResult Upload()
        {
            return View();
        }

        // [HttpPost]
        // public ActionResult Upload(HttpPostedFileBase file)
        // {
        //     if (file != null)
        //     {
        //         var path = Path.Combine(Server.MapPath("~/Uploads"), file.FileName);
        //         file.SaveAs(path); // intentionally unsafe
        //         ViewBag.Message = "File uploaded: " + file.FileName;
        //     }
        //     return View();
        // }



}