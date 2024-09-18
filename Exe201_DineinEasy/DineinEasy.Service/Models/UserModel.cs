using System;
using System.Collections.Generic;

namespace DineinEasy.Service.Models;

public partial class UserModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int Role { get; set; }

    public string Password { get; set; }

    public DateTime CreateAt { get; set; }

    public bool Status { get; set; }
}