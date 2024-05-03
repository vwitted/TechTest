using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    [Route("delete/{id}")]
    public RedirectToActionResult Delete(long id = 1)
    {
        var toDelete = _userService.GetAll().First(x => x.Id == id);
        _userService.Delete(toDelete);
        return RedirectToAction("List");
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
