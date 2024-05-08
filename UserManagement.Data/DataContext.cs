using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<User>().ToTable("User").HasData(new[]
        {
            new User { Id = 1, Forename = "Peter", Surname = "Loew", Email = "ploew@example.com", DateOfBirth=DateTime.ParseExact("21/05/1980","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 2, Forename = "Benjamin Franklin", Surname = "Gates", Email = "bfgates@example.com", DateOfBirth=DateTime.ParseExact("01/01/1990","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 3, Forename = "Castor", Surname = "Troy", Email = "ctroy@example.com", DateOfBirth=DateTime.ParseExact("10/04/1997","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = false },
            new User { Id = 4, Forename = "Memphis", Surname = "Raines", Email = "mraines@example.com", DateOfBirth=DateTime.ParseExact("30/05/1988","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 5, Forename = "Stanley", Surname = "Goodspeed", Email = "sgodspeed@example.com", DateOfBirth=DateTime.ParseExact("07/02/1995","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 6, Forename = "H.I.", Surname = "McDunnough", Email = "himcdunnough@example.com", DateOfBirth=DateTime.ParseExact("19/11/1989","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 7, Forename = "Cameron", Surname = "Poe", Email = "cpoe@example.com", DateOfBirth=DateTime.ParseExact("09/04/1992","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = false },
            new User { Id = 8, Forename = "Edward", Surname = "Malus", Email = "emalus@example.com", DateOfBirth=DateTime.ParseExact("01/01/2001","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = false },
            new User { Id = 9, Forename = "Damon", Surname = "Macready", Email = "dmacready@example.com", DateOfBirth=DateTime.ParseExact("01/05/1999","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = false },
            new User { Id = 10, Forename = "Johnny", Surname = "Blaze", Email = "jblaze@example.com", DateOfBirth=DateTime.ParseExact("27/10/1989","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
            new User { Id = 11, Forename = "Robin", Surname = "Feld", Email = "rfeld@example.com", DateOfBirth=DateTime.ParseExact("04/04/1996","dd/MM/yyyy",CultureInfo.InvariantCulture), IsActive = true },
        });
        model.Entity<ActionLog>().ToTable("ActionLog");
    }

    public DbSet<ActionLog> ActionLogs { get; set; }

    public DbSet<User>? Users { get; set; }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public TEntity Get<TEntity>(TEntity entity) where TEntity : class
    {
        return entity;
    }

    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add(entity);
        SaveChanges();
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        base.Update(entity);
        SaveChanges();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        base.Remove(entity);
        SaveChanges();
    }
}
