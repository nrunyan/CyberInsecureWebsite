using Microsoft.AspNetCore.Mvc;
using InsecureWebsite.Models;

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
            results.Add($"{reader.GetString(0)} | Rating: {reader.GetDouble(1)} | Budget: ${reader.GetInt64(2):N0} | Year: {reader.GetInt32(3)}");

        ViewBag.Search = search;
        ViewBag.Results = results;
        return View();
    }
}
