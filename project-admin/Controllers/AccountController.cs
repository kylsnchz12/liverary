using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using Microsoft.AspNetCore.Mvc;
using project_admin.Models;
using project_admin.Data;

using Microsoft.AspNetCore.Mvc;
using project_admin.Data; 
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller {
    private readonly AppDbContext _appDbContext;
    public AccountController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Login()
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

    [HttpGet]
    public async Task<IActionResult> View(Guid userID)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserID == userID);

        if(user != null)
        {
            var viewModel = new UpdateUserViewModel()
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password
            };
            return await Task.Run(() => View("View", viewModel));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> View(UpdateUserViewModel model)
    {
        var user = await _appDbContext.Users.FindAsync(model.UserID);

        if(user != null)
        {
            user.UserID = model.UserID;
            user.Username = model.Username;
            user.Password = model.Password;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(UserList));
        }
        return RedirectToAction(nameof(Index)); 
    }

    [HttpPost]
    public async Task<IActionResult> Delete(UpdateUserViewModel model)
    {
        var user = await _appDbContext.Users.FindAsync(model.UserID);
        if(user != null)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(UserList));
        }
        return RedirectToAction(nameof(Index)); 
    }

}