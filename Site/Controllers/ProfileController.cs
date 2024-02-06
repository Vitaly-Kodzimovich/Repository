using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

using Users_Database;

namespace Site.Controllers;

public class ProfileController : Controller
{
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ILogger<ProfileController> logger)
    {
        _logger = logger;
    }




    [HttpGet]
    public async Task Registration()
    {
        string content = @"<h1>Registration</h1><form method='post'>
            <label>Name:</label><br />
            <input name='name' /><br />
            <label>Password:</label><br />
            <input name='password' /><br />
            <input type='submit' value='Register' />
        </form>";
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync(content);
    }
    [HttpPost]
    public async Task Registration(string name, string password)
    {
        Database db = new Database();
        string[] User = {name,password,"2"};
        db.NewUser(User);

        string content = "";
        content += "<h2>You registration was successful</h2>";
        content += $"<h1>Hello {name}</h1>";
        Response.ContentType = "text/html;charset=utf-8";

        HttpContext.Response.Cookies.Append("Name", $"{name}");
        HttpContext.Response.Cookies.Append("Password", $"{db.CreateMD5(password)}");

        await Response.WriteAsync(content); 
    }





    [HttpGet]
    public async Task Login()
    {
        string content = @"<h1>Login</h1><form method='post'>
            <label>Name:</label><br />
            <input name='name' /><br />
            <label>Password:</label><br />
            <input name='password' /><br />
            <input type='submit' value='Log in' />
        </form>";
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync(content);
    }
    [HttpPost]
    public async Task Login(string name, string password)
    {
        Database db = new Database();
        string[] User = {name,password};

        string content = "";
        if(db.CheckUser(User) == true)
        {
            content += $"<p>Connecting successfull<p><h1>Hello {name}</h1>";
            HttpContext.Response.Cookies.Append("Name", $"{name}");
            HttpContext.Response.Cookies.Append("Password", $"{db.CreateMD5(password)}");
        }else
        {
            content += "<p>Wrong Username or Password<p>";
        }

        
        Response.ContentType = "text/html;charset=utf-8";
        await Response.WriteAsync(content); 
    }




    public IActionResult Main()
    {
        Database db = new Database();
        //ViewData["Message"] = db.CreateMD5("HEllo");

        if (HttpContext.Request.Cookies.TryGetValue("Name", out var Name))
        {
            ViewData["Message"] = "Hello " + Name + "!";
            //HttpContext.Response.Cookies.Append("name", "Tommy");
        }
        else
        {
            ViewData["Message"] = "Noname";
        }

        return View();
    }
}
