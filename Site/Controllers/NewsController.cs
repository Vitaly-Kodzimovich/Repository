using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

using News_Database;

namespace Site.Controllers;

public class NewsController : Controller
{
    private readonly ILogger<NewsController> _logger;

    public NewsController(ILogger<NewsController> logger)
    {
        _logger = logger;
    }
    public IActionResult NewsPage(int id)
    {
        Database db = new Database();
        var data = db.GetOneElement(id);

        var path = HttpContext.Request.Path;

        ViewData["Message"] = $"{data[0][3]}";
        return View();
    }

    public IActionResult Main()
    {
        Database db = new Database();
        
        var MainPage_Data = db.GetOneElement(781);
        var Page1_Data = db.GetOneElement(23);
        var Page2_Data = db.GetOneElement(779);
        var Page3_Data = db.GetOneElement(22);
        var Page4_Data = db.GetOneElement(785);
        var Page5_Data = db.GetOneElement(786);

        ViewBag.MainPage = new List<string>{$"{MainPage_Data[0][0]}",$"{MainPage_Data[0][1]}", $"{MainPage_Data[0][2]}"};
        ViewBag.Page1    = new List<string>{$"{Page1_Data[0][0]}",$"{Page1_Data[0][1]}",$"{Page1_Data[0][2]}"};
        ViewBag.Page2    = new List<string>{$"{Page2_Data[0][0]}",$"{Page2_Data[0][1]}",$"{Page2_Data[0][2]}"};
        ViewBag.Page3    = new List<string>{$"{Page3_Data[0][0]}",$"{Page3_Data[0][1]}",$"{Page3_Data[0][2]}"};
        ViewBag.Page4    = new List<string>{$"{Page4_Data[0][0]}",$"{Page4_Data[0][1]}",$"{Page4_Data[0][2]}"};
        ViewBag.Page5    = new List<string>{$"{Page5_Data[0][0]}",$"{Page5_Data[0][1]}",$"{Page5_Data[0][2]}"};
        return View();
    }

    public IActionResult News()
    {
        Database db = new Database();

        ViewBag.News = db.GetAllData();

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}