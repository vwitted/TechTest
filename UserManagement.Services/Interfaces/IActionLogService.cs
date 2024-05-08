using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Interfaces;

public interface IActionLogService
{
    void GenerateLog(long userId, ActionType actionType);

    IEnumerable<ActionLog> GetAll();

    IEnumerable<ActionLog> GetById(long userId);
}
