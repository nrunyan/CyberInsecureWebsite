using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;

namespace InsecureWebsite.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
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
        
        return RedirectToAction("Index",u);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



[HttpPost]
[Route("AlertMaintenance/SaveAlert")]
public async Task<IActionResult> SaveAlert([FromBody] AlertDto alertDto)
{
    
    alertDto.AlertId = GenerateNewAlertId(alertDto.OldAlertId ?? 0);
    alertDto.CreatedBy = _userSecurityService.ActualUserLoginName;

    var result = await _alertMaintenanceFactory.SaveAlert(alertDto);

    // 3. If save succeeded, delete old alert
    if (result != null && alertDto.OldAlertId.HasValue)
    {
        await _alertMaintenanceFactory.DeleteAlert(
            new AlertDto { AlertId = alertDto.OldAlertId.Value }
        );
    }

    return Json(result);
}

}
