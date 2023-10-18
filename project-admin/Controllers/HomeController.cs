using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using project_admin.Data;

using Microsoft.AspNetCore.Mvc;
using project_admin.Data; 
using Microsoft.Extensions.Logging; 
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _appDbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {   
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddUserViewModel addUserRequest)
    {   
        var user = new User()
        {
            UserID = Guid.NewGuid(),
            Username = addUserRequest.Username,
            Password = addUserRequest.Password
        };

        _appDbContext.Add(user);
        await _appDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UserList()
    {
        var users = await _appDbContext.Users.ToListAsync();
        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


// namespace project_admin.Controllers;

// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;

//     public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }

//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     public IActionResult Create()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }
