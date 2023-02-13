using System;
using System.Collections.Generic;

namespace PPM.DAL.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
