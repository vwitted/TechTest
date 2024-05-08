using System;

namespace UserManagement.Web.Models.Users;

public class UserActionLogModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Action { get; set; } = default!;
    public DateTime Timestamp { get; set; }
}
