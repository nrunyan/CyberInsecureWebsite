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
            ViewBag.FlagError = "";
            return RedirectToAction("Medium");
        }

        ViewBag.FlagError = "Wrong flag!";
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

        var results = new List<(string name, string code)>();

        using var connection = SqlDatabase.GetTimeConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT name, code, future_gdp, future_population FROM countries WHERE name LIKE '%{search}%'";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            results.Add(($"{reader.GetString(0)} | Future GDP: {reader.GetInt64(2)} | Future Population: {reader.GetInt64(3)}", reader.GetString(1)));
        }
        ViewBag.Search = search;
        ViewBag.Results = results;
        return View();
    }

    [HttpPost]
    public IActionResult MediumFlag(string flag)
    {
        if (flag == "6f6eb17d4388c8c0ec0ba5555ef7312722c02d453aa0ce16869aadc9f001f3fb")
        {
            HttpContext.Session.SetString("med_complete", "true");
            ViewBag.FlagError = "";
            return RedirectToAction("Hard");
        }

        ViewBag.FlagError = "Wrong flag!";
        return View("Easy");
    }

    public IActionResult Hard()
    {
        if (HttpContext.Session.GetString("med_complete") != "true")
        {
            return RedirectToAction("Easy");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Hard(string search)
    {
        search = search.Replace("'", "").Replace("\"", "");
        search = search.Replace("--", "").Replace("/*", "").Replace("*/", "");
        search = Regex.Replace(search, "union", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "select", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "from", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "where", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "insert", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "update", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "delete", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "drop", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "table", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "database", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "join", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "having", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "order", "", RegexOptions.IgnoreCase);
        search = Regex.Replace(search, "limit", "", RegexOptions.IgnoreCase);

        var results = new List<string>();

        using var connection = SqlDatabase.GetCriticalConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT year, celebrity_death, scientific_discovery FROM timeline WHERE year = {search}";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
            results.Add($"Year: {reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetString(2)}");

        ViewBag.Search = search;
        ViewBag.Results = results;
        return View();
    }

    [HttpPost]
    public IActionResult HardFlag(string flag)
    {
        if (flag == "LOCK")
        {
            HttpContext.Session.SetString("hard_complete", "true");
            return RedirectToAction("Index", "Hub");
        }

        ViewBag.FlagError = "Wrong flag!";
        return View("Hard");
    }
}
