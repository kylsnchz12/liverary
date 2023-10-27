﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using project_admin.Data;

using Microsoft.AspNetCore.Mvc;
using project_admin.Data; 
using Microsoft.Extensions.Logging; 
using Microsoft.EntityFrameworkCore;

namespace project_admin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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
