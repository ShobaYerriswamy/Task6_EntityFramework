using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using PPM.MODEL;
using PPM.DAL.Models;

namespace PPM.DAL;
public class EmployeeDal
{
    public void AddToEmployeeTable (int employeeId, string firstName, string lastName, string email, string mobileNumber, string address, int roleId)
    {
        try
        {
           using (ppmContext context = new ppmContext())
           {
                PPM.DAL.Models.Employee employee = new Models.Employee()
                {
                    EmployeeId = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    MobileNumber = mobileNumber,
                    Address = address,
                    RoleId = roleId
                };

                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Added Succesfully...");
           }

        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
    }

    public void ToViewEmployeeData()
    {
        using (ppmContext context = new ppmContext())
        {
            var employeelist = context.Employees.ToList();
            foreach (var employee in employeelist)
            {
                Console.WriteLine($" Employee Id - {employee.EmployeeId}, Employee First Name - {employee.FirstName}, Employee Last Name - {employee.LastName}, Email - {employee.Email}, Mobile Number - {employee.MobileNumber}, Address - {employee.Address}, Employee RoleId - {employee.RoleId}");
            }
        }
    }

    public void DeleteEmployeeFromTable (int employeeId)
    {
        try
        {
           using (ppmContext context = new ppmContext())
           {
                PPM.DAL.Models.Employee employee = context.Employees.Find (employeeId);
                if(employee != null )
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Deleted Successfully");
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
    }

    public Boolean ExistsInEmployeeTable (int employeeId)
    {
        try
        {
            using (ppmContext context = new ppmContext())
            {
                PPM.DAL.Models.Employee employee = context.Employees.Find (employeeId);
                if(employee != null )
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

    public void ViewEmployeeDataById(int employeeId)
    {
        using (ppmContext context = new ppmContext())
        {
            PPM.DAL.Models.Employee employee = context.Employees.Find (employeeId);
            if(employee != null )
            {
                var employee1 = context.Roles.Find(employeeId);
                Console.WriteLine($" Employee Id - {employee.EmployeeId}, Employee First Name - {employee.FirstName}, Employee Last Name - {employee.LastName}, Email - {employee.Email}, Mobile Number - {employee.MobileNumber}, Address - {employee.Address}, Employee RoleId - {employee.RoleId}");
            }
            else
            {
                    Console.WriteLine("No Role Found with this Id");
            }
        }
    }
}

