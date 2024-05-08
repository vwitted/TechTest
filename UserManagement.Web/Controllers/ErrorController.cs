using System;
using System.Diagnostics;

namespace UserManagement.Web.Controllers;
public class ErrorController : Controller
{
    [HttpGet]
    public IActionResult Error(int? statusCode, Exception exception)
    {
        var viewModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        if (statusCode.HasValue)
        {
            if (statusCode == 404)
            {
                ViewData["ErrorMessage"] = "The requested resource was not found.";
            }

            //other codes here
            else
            {

            }
        }

        return View();
    }
}
