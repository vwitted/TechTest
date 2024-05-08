
using System.Linq;
using UserManagement.Services.Interfaces;
using X.PagedList;

namespace UserManagement.Web.Controllers;

[Route("logs")]
public class LogsController : Controller    
{
    private readonly IActionLogService _actionLogService;

    public LogsController(IActionLogService actionLogService)
    {
        _actionLogService = actionLogService;
    }

    [HttpGet]
    public ActionResult Logs(int? page)
    {
        int pageSize = 10; // Number of logs per page
        int pageNumber = (page ?? 1); // Current page number
        var actionLogs = _actionLogService.GetAll()
            .OrderByDescending(log => log.Timestamp)
            .ToPagedList(pageNumber, pageSize);

        return View(actionLogs);
    }
}
