using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using PPM.MODEL;
using PPM.DAL.Models;

namespace PPM.DAL;
public class RoleDal
{
    public void AddToRoleTable (int roleId, string roleName)
    {
        try
        {
            using(ppmContext context = new ppmContext())
            {
                PPM.DAL.Models.Role role = new Models.Role()
                {
                    RoleId = roleId,
                    RoleName = roleName
                };

                context.Roles.Add(role);
                context.SaveChanges();
                Console.WriteLine("Added Succesfully...");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
    }

    public void ToViewRoleData()
    {
        using (ppmContext context = new ppmContext())
        {
            var rolelist = context.Roles.ToList();
            foreach (var role in rolelist)
            {
                Console.WriteLine($" Role Id - {role.RoleId}, Role Name - {role.RoleName}");
            }
        }
    }

    public Boolean ExistsInRoleTable (int roleId)
    {
        try
        {
            using (ppmContext context = new ppmContext())
            {
                PPM.DAL.Models.Role role = context.Roles.Find (roleId);
                if(role != null )
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

    public void DeleteRoleFromTable (int roleId)
    {
        try
        {
           using (ppmContext context = new ppmContext())
           {
                PPM.DAL.Models.Role role = context.Roles.Find (roleId);
                if(role != null )
                {
                    context.Roles.Remove(role);
                    context.SaveChanges();
                    Console.WriteLine("Deleted Successfully");   
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

    public void ViewRoleDataById (int roleId)
    {
        using (ppmContext context = new ppmContext())
        {
            PPM.DAL.Models.Role role = context.Roles.Find (roleId);
            if(role != null )
            {
                var role1 = context.Roles.Find(roleId);
                Console.WriteLine($" Role Id - {role.RoleId}, Role Name - {role.RoleName}");
            }
            else
            {
                Console.WriteLine("No Role Found with this Id");
            }
        }
    }

    public Boolean ExistsRoleInEmployeeTable (int roleId)
    {
        try
        {
            using (ppmContext context = new ppmContext())
            {
                foreach (var employee in context.Employees)
                {
                    if (employee.RoleId == roleId)
                    {
                        return true;
                    }
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("OOPs, something went wrong.\n" + e);
        }
        return false;
    }  
}
