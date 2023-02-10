﻿using System;
using System.Collections.Generic;

namespace PPM.DAL.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
