﻿using System;
using System.Collections.Generic;

namespace PPM.DAL.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public string? Address { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
