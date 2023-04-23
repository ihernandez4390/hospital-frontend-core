using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using hospital_frontend_core.Models;
using hospital_frontend_core.Services;

namespace hospital_frontend_core.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,  hospital_backend_client _client) : base(_client)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        var model = new credential();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var credential = new credential() {
            username = username,
            password = password
        };

        var result = await base.client.Login(credential);

        if (result)
            return RedirectToAction("Home");
        else
            return RedirectToAction("Login");
    }

    public async Task<IActionResult> Logout() 
    {
        await base.client.Logout();

        return RedirectToAction("Login");
    }

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
