using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Services.Interfaces;
using UserManagement.Web;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IActionLogService _actionLogService;

    public UsersController(IUserService userService, IActionLogService actionLogService)
    {
        _userService = userService;
        _actionLogService = actionLogService;
    }


    [HttpGet]
    [Route("view")]
    public IActionResult View(long id)
    {
        var user = new User();
        try
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            user = _userService.GetUserById(id);

            if (user == null)
            {
                throw new InvalidUserException();
            }
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidUserException ex)
        {
            return BadRequest(ex.Message);
        }
    
        var model = new UserViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            IsActive = user.IsActive
        };
        _actionLogService.GenerateLog(user.Id, ActionType.Viewed);
        ViewBag.UserActionLogs = _actionLogService.GetById(user.Id);
        return View(model);
    }


    [HttpGet]
    [Route("edit")]
    public IActionResult Edit(long id)
    {
        var user = new User();
        try
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidUserException ex)
        {
            return BadRequest(ex.Message);
        }
        var model = new UserEditViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            IsActive = user.IsActive
        };

        return View(model);
    }

    [HttpPost]
    [Route("edit")]
    public IActionResult Edit(UserEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _userService.GetUserById(model.Id);
            if (user == null)
            {
                return NotFound();
            }
            user.Forename = model.Forename;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.DateOfBirth = model.DateOfBirth;
            user.IsActive = model.IsActive;

            _userService.Update(user);
            _actionLogService.GenerateLog(user.Id, ActionType.Edited);
            return RedirectToAction("List");
        }

        return View(model);
    }


    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(UserAddViewModel model)
    {

        if (ModelState.IsValid)
        {

            var newUser = new User
            {
                Forename = model.Forename,
                Surname = model.Surname,
                Email =  model.Email,
                DateOfBirth = model.DateOfBirth
            };

            _userService.Create(newUser);
            _actionLogService.GenerateLog(newUser.Id, ActionType.Created);
            return RedirectToAction("List");
        }
        return View(model);
    }

    [HttpGet]
    [Route("delete/{id}")]
    public RedirectToActionResult Delete(long id = 1)
    {
        try
        {
            if (id <= 1)
            {
                throw new ArgumentException();
            }
            var toDelete = _userService.GetAll().First(x => x.Id == id);
            _userService.Delete(toDelete);
            _actionLogService.GenerateLog(toDelete.Id, ActionType.Deleted);

            return RedirectToAction("List");
        }
        catch (ArgumentException)
        {
            
            throw;
        }
     }
    
    [HttpGet]
    public ViewResult List(string filter = "all")
    {
        IEnumerable<UserListItemViewModel> items = new List<UserListItemViewModel>();
        switch (filter)
        {
            case "all":
                items = _userService.GetAll().Select(p => new UserListItemViewModel
                {
                    Id = p.Id,
                    Forename = p.Forename,
                    Surname = p.Surname,
                    Email = p.Email,
                    DateOfBirth = p.DateOfBirth,
                    IsActive = p.IsActive
                });
                break;
            case "active":
                items = _userService.FilterByActive(true).Select(p => new UserListItemViewModel
                {
                    Id = p.Id,
                    Forename = p.Forename,
                    Surname = p.Surname,
                    Email = p.Email,
                    IsActive = p.IsActive
                });
                break;
            case "inactive":
                items = _userService.FilterByActive(false).Select(p => new UserListItemViewModel
                {
                    Id = p.Id,
                    Forename = p.Forename,
                    Surname = p.Surname,
                    Email = p.Email,
                    IsActive = p.IsActive
                });
                break;
        }   


        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

     


   
}
