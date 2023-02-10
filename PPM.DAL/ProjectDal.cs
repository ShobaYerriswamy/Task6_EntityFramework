using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using PPM.MODEL;
using PPM.DAL.Models;


namespace PPM.DAL;
public class ProjectDal 
{
    private object context;

    public void AddToProjectTable (int projectId, string projectName, string startDate, string endDate)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                PPM.DAL.Models.Project project = new Models.Project()
                {
                    ProjectId = projectId,
                    ProjectName = projectName,
                    StartDate = startDate,
                    EndDate =endDate
                };

                context.Projects.Add(project);
                context.SaveChanges();
                Console.WriteLine("Added Succesfully...");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
    }

    public void ToViewProjectData()
    {
        using (ppmContext context = new ppmContext())
        {
            var projectlist = context.Projects.ToList();
            foreach (var project in projectlist)
            {
                Console.WriteLine($" Project Id - {project.ProjectId}, Project Name - {project.ProjectName}, StartDate - {project.StartDate}, EndDate - {project.EndDate}");
            }
        }
    }

    public Boolean ExistsInProjectTable (int projectId)
    {
        try
        {
            using (ppmContext context = new ppmContext())
            {
                PPM.DAL.Models.Project project = context.Projects.Find (projectId);
                if(project != null )
                {
                    return true;
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
        return false;
    }

    public void DeleteProjectFromTable (int projectId)
    {
        try
        {
           using (ppmContext context = new ppmContext())
           {
                PPM.DAL.Models.Project project = context.Projects.Find (projectId);
                if(project != null )
                {
                    context.Projects.Remove(project);
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted");   
                }
                else 
                {
                    Console.WriteLine("Role Id does not Exists...");
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        } 
    }

    public void ViewProjectDataById (int projectId)
    {
        using (ppmContext context = new ppmContext())
        {
            PPM.DAL.Models.Project project = context.Projects.Find (projectId);
            if(project != null )
            {
                var Project = context.Roles.Find(projectId);
                Console.WriteLine($" Project Id - {project.ProjectId}, Project Name - {project.ProjectName}, StartDate - {project.StartDate}, EndDate - {project.EndDate}");
            }
            else
            {
                    Console.WriteLine("No Project Found with this Id");
            }
        }
    }
    
    // public void AddEmployeesToProject(int projectId, int employeeId)
    // {
    //     using(ppmContext context = new ppmContext())
    //     {
    //         var employee = context.Employees.Find(employeeId);
    //         if(employee != null)
    //         {
	// 	        context.Projects.Include(x => x.Employees).FirstOrDefault(x => x.ProjectId == projectId).Employees.Add(employee);
	//     	    context.SaveChanges();
    //         }
	//         else
    //         {
    //             Console.WriteLine("Employee not available ");
	// 	    }
    //     }
    // }

    public void DeleteEmployeeFromProject(int projectId, int employeeId)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                var employee = context.Employees.Find(employeeId);
                context.Projects.Include(x => x.Employees).Where(x => x.ProjectId == projectId).First().Employees.Remove(employee);
                context.SaveChanges();
                Console.WriteLine("Deleted Successfully");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        } 
    }

    public void AddEmployeesToProject(int projectId, int employeeId)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                var employee = context.Employees.Find(employeeId);
                context.Projects.Find(projectId).Employees.Add(employee);
                context.SaveChanges();
            }
                
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops error occured  " + ex);
        }
    }

    public Boolean IfExistsInProjectsWithEmployees(int projectId, int employeeId)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                var employee = context.Employees.Find(employeeId);
                var employeeList = context.Projects.Include(p => p.Employees).ThenInclude(x => x.RoleId).Where(x => x.ProjectId == projectId).First().Employees.ToList();
                if (employeeList.Contains(employee))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops, error occured");
        }
        return false;
    }

    public Boolean IfExistsInProjectsWithEmployeesTable(int projectId)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                if (context.Projects.Find(projectId).Employees != null)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops, error occured" + ex);
        }
        return false;
    }
}

               
