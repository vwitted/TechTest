﻿using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> FilterByActive(bool isActive)
    {
        return _dataAccess.GetAll<User>().Where(x => isActive == x.IsActive);
    }

    public IEnumerable<User> GetAll()
    {
      return _dataAccess.GetAll<User>();
    }

    public User GetUserById(long id)
    {
       
            var users = _dataAccess.GetAll<User>();
            return _dataAccess.GetAll<User>().First(x => id == x.Id);
       
    }

    public void Delete(User user)
    {
        _dataAccess.Delete<User>(user);
    }

    public void Create(User user)
    {
        _dataAccess.Create<User>(user);
    }

    public void Update(User user)
    {
        _dataAccess.Update<User>(user);
    }


}
