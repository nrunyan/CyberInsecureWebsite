using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;
using System.Text.RegularExpressions;

namespace InsecureWebsite.Controllers;

public class Level3Controller : Controller
{
    public IActionResult Index() => View();

    public IActionResult Easy() => View();

    [HttpPost]
    public IActionResult Easy(string search)
    {
        var results = new List<string>();

        using var connection = SqlDatabase.GetFactsConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT name, rating, budget, release FROM movies WHERE name LIKE '%{search}%'";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            results.Add($"{reader.GetString(0)} | Rating: {reader.GetDouble(1)} | Budget: ${reader.GetInt64(2):N0} | Year: {reader.GetInt32(3)}");
        }
        ViewBag.Search = search;
        ViewBag.Results = results;
        return View();
    }

    [HttpPost]
    public IActionResult EasyFlag(string flag)
    {
        if (flag == "The Matrix 5-tastic and Furious")
        {
            HttpContext.Session.SetString("easy_complete", "true");
            return RedirectToAction("Medium");
        }

        ViewBag.FlagError = "Wrong Flag!";
        return View("Easy");
    }

    public IActionResult Medium()
    {
        if (HttpContext.Session.GetString("easy_complete") != "true")
        {
            return RedirectToAction("Easy");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Medium(string search)
    {
        search = Regex.Replace(search, "union", "", RegexOptions.IgnoreCase);
        search = search.Replace("--", "");
        return View();
    }
}
