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
                
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
    // public ViewResult Login()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public ActionResult Login(Username u)
    // {
    //     if(u.Name=="Vinnie Gar" && u.Password == "PickleMe") //oh how foolish, a pickle joke
    //     {
    //         return View("Congratulations",new Congrats("LoginLevel1","Please return to the hub and reselect login to move on"));
    //     }
    //     Repository.AddUsername(u);
    //     return View("Thanks",u);
    // }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


   
       
        

       
        // public ActionResult Upload()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public ActionResult Upload(HttpPostedFileBase file)
        // {
        //     if (file != null)
        //     {
        //         var path = Path.Combine(Server.MapPath("~/Uploads"), file.FileName);
        //         file.SaveAs(path); //intentionally unsafe
        //         ViewBag.Message = "File uploaded: " + file.FileName;
        //     }
        //     return View();
        // }



}