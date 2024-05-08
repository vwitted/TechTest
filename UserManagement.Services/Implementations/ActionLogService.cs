using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Interfaces;

namespace UserManagement.Services.Implementations;

public class ActionLogService : IActionLogService
{

    private readonly IDataContext _dataAccess;
    public ActionLogService(IDataContext dataAccess) => _dataAccess = dataAccess;

    private void Add(ActionLog log)
    {
        _dataAccess.Create<ActionLog>(log);
    }

    public void GenerateLog(long userId, ActionType actionType)
    {
        var log = new ActionLog()
        {
            UserId = userId,
            Action = actionType,
            Timestamp = DateTime.Now
        };

        Add(log);
    }

    public IEnumerable<ActionLog> GetById(long userId)
    {
       return _dataAccess.GetAll<ActionLog>().Where(x=>x.UserId == userId);
    }

    IEnumerable<ActionLog> IActionLogService.GetAll()
    {
        return _dataAccess.GetAll<ActionLog>();
    }
}
