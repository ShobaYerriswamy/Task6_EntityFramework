using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PPM.DAL;
using PPM.MODEL;
using PPM.DOMAIN;

namespace UserInterface
{
    public class Viewing
    {
        public void View()
        {
            ProjectManager projectManager =  new ProjectManager();
            EmployeeManager employeeManager = new EmployeeManager();
            RoleManager roleManager = new RoleManager();

            ProjectDal projectDal = new ProjectDal();
            EmployeeDal employeeDal =  new EmployeeDal();
            RoleDal roleDal = new RoleDal();

            Boolean error = false;

            Regex phonenumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            View:

                Console.WriteLine("");
                Console.WriteLine(" ***** HELLO PROLIFICS EMPLOYEE ***** ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 1 to View Project Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 2 to View Employee Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 3 to View Role Module");
                Console.WriteLine("");
                Console.WriteLine(" Enter 'S' to QUIT the Application ");
                Console.WriteLine("");

                var UserInput = Console.ReadLine();

                while (true)
                {
                    repeat:

                    switch (UserInput)
                    {
                        case "1":
                            while (true)
                            {
                                projectModule:

                                Console.WriteLine(" ***** PROJECT MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Project ");
                                Console.WriteLine(" Enter 2 to List All Projects ");
                                Console.WriteLine(" Enter 3 to List Project By Id ");
                                Console.WriteLine(" Enter 4 Add Employee to Project ");
                                Console.WriteLine(" Enter 5 Delete Employee from Project ");
                                Console.WriteLine(" Enter 6 to View Employees in Project ");
                                Console.WriteLine(" Enter 7 to Delete Project ");
                                Console.WriteLine(" Enter \"x\" to Exit to Main Menu ");
                                Console.WriteLine("");

                                var projectSelector =  Console.ReadLine();

                                switch(projectSelector)
                                {
                                    case "1":
                                        
                                        do
                                        {
                                            try
                                            {
                                                inputprojectid:
                                                    Console.WriteLine("Enter the Project ID");
                                                    int projectid = Convert.ToInt32(Console.ReadLine());
                                                        if (projectDal.ExistsInProjectTable(projectid))
                                                        {
                                                            Console.WriteLine("This ID already exists try new ID");
                                                            Console.WriteLine("Enter any key to Try Again");
                                                            Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                            string idTry = Console.ReadLine();

                                                            if (idTry == "x")
                                                            {
                                                                goto projectModule;
                                                            }
                                                            else
                                                            {   
                                                                goto inputprojectid;
                                                            }
                                                        }
                                        
                                                    Console.WriteLine("Enter the Name of Project");
                                                    string name = Console.ReadLine();
                                
                                                StartDate:

                                                    Console.WriteLine("Enter the Start Date of Project DD/MM/YYYY format");
                                                
                                                    string start = Console.ReadLine();
                                
                                                    if(!date.IsMatch(start))
                                                    {
                                                        Console.WriteLine("Invalid Date Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                        var sDateread=Console.ReadLine();

                                                        if(sDateread == "x")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            goto StartDate;
                                                        }
                                                    }
                                
                                                EndDate:

                                                    Console.WriteLine("Enter End Date of Project in DD/MM/YYYY format");
                                                
                                                    string end = Console.ReadLine();
                                                
                                                    if (!date.IsMatch(end))
                                                    {
                                                        Console.WriteLine("Invalid Date Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter \"x\" to Exit to Main Menu");
                                    
                                                        var eDateread = Console.ReadLine();
                                    
                                                        if (eDateread == "x")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {   
                                                            goto EndDate;
                                                        }
                                                    }

                                                    Project project1 = new Project(name, start, end, projectid);
                                                    projectManager.AddProject(project1);
                                                    Console.WriteLine("Added Successfully");

                                                    Console.WriteLine(" Would You Like To Add Employees to this Project? ");
                                                    Console.WriteLine("Enter \"Yes\" to Add or Enter Anything to Deny");

                                                    var addEmployeeOrNot = Console.ReadLine();

                                                    if (addEmployeeOrNot == "Yes")
                                                    {
                                                        projectDal.ToViewProjectData();
                                                        Console.WriteLine(" ***** Above are the Available Projects ***** ");
                                                        Console.WriteLine();
                                                        employeeManager.ListAllEmployees();
                                                        Console.WriteLine(" ***** Above are the Available Employees ***** ");
                                                        Console.WriteLine();
                                                        Console.WriteLine("Enter the ID of Employee to Add into Project");
                                                        int employeeIdSelect = Convert.ToInt32(Console.ReadLine());
                                                        if (employeeDal.ExistsInEmployeeTable(employeeIdSelect))
                                                        {
                                                            projectManager.AddEmployeesToProject(projectid, employeeIdSelect);
                                                            Console.WriteLine("Added Successfully");
                                                        } 
                                                        else 
                                                        {
                                                            Console.WriteLine("Employee Does Not Exist");
                                                        }
                                                    }

                                                    Console.WriteLine("Enter any key to get Main Menu");
                                                    Console.ReadLine();
                                            }

                                            catch(FormatException e)
                                            {
                                                Console.WriteLine("\nError : only use Numbers for ID");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                                                UserInput= Console.ReadLine();
                                            
                                                if(UserInput == "x")
                                                {
                                                    break;
                                                }
                                                error = true;
                                            }
                                            catch(Exception e)
                                            {
                                                Console.WriteLine("\nError : only use Numbers for ID");
                                                Console.WriteLine("Enter any key to Try Again");
                                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                            
                                                UserInput= Console.ReadLine();
                                            
                                                if(UserInput == "x")
                                                {
                                                    break;
                                                }
                                                error = true;
                                            }
                                        }

                                        while(error);
                                        break;
                        
                                    case "2":
                                        
                                        projectManager.ListAllProjects();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        
                                        try
                                        {
                                            Console.WriteLine("Serach Via Project ID");
                                            Console.WriteLine("Enter the ID of Project");
                                            int Eid = Convert.ToInt32(Console.ReadLine());
                                            projectManager.ListAllProjectsById(Eid);
                                            Console.WriteLine("Enter any key to get Main Menu");
                                            Console.ReadLine();
                                        }

                                        catch(Exception e)
                                        {
                                            Console.WriteLine("ID can be only in Numbers");
                                        }
                                        break;

                                    case "4":
                                        try
                                        {
                                            projectDal.ToViewProjectData();
                                            Console.WriteLine(" ***** Above are the Available Projects ***** ");
                                            Console.WriteLine();
                                            employeeDal.ToViewEmployeeData();
                                            Console.WriteLine(" ***** Above are the Available Employees ***** ");
                                            Console.WriteLine();
                                            Console.WriteLine("Enter the ID of the Project which you want to Add Employee");
                                            int PROJId = Convert.ToInt32(Console.ReadLine());
                                            if(projectDal.ExistsInProjectTable(PROJId))
                                            {
                                                Console.WriteLine("Enter the Id of the Employee to Add into Project");
                                                int EMPId = Convert.ToInt32(Console.ReadLine());
                                                if (employeeDal.ExistsInEmployeeTable (EMPId))
                                                {
                                                    if (!projectDal.IfExistsInProjectsWithEmployees(PROJId,EMPId ))
                                                    {
                                                        projectManager.AddEmployeesToProject(PROJId, EMPId);
                                                        Console.WriteLine("Succesfully Added..");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Employee Already Exists With this Id");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Employee Does Not Exists..");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Project Does Not Exists..");
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("OOPs, something went wrong.\n"); 
                                        }
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "5":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Project which you want to Delete Employee");
                                            int PROJId1 = Convert.ToInt32(Console.ReadLine());
                                            if (projectDal.ExistsInProjectTable(PROJId1))
                                            {
                                                Console.WriteLine("Enter the Id of the Employee to Delete from Project");
                                                int EMPId1 = Convert.ToInt32(Console.ReadLine());
                                                if (projectDal.IfExistsInProjectsWithEmployees(PROJId1,EMPId1 ))
                                                {
                                                    projectManager.DeleteEmployeesFromProject(PROJId1,EMPId1);
                                                    Console.WriteLine("Succesfullu Deleted");
                                                } 
                                                else
                                                {
                                                    Console.WriteLine("This Employee Not Exists In Project");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Project Not Found");
                                                
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("ID can be only in Interger");
                                        }
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "6" :
                                        try
                                        {
                                            Console.WriteLine("Enter the Id of the Project");
                                            int readForId = Convert.ToInt32(Console.ReadLine());
                                            if (projectDal.ExistsInProjectTable(readForId))
                                            {
                                                if (projectDal.ExistsInProjectsWithEmployeesTable(readForId))
                                                {
                                                    projectManager.ViewAllEmployeesInProjectById(readForId);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No Employee in this Project");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No Project Present with this ID");
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("ID can only in Number");
                                        }
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;


                                    case "7":
                                    
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Project to Delete");
                                            int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                            if (projectDal.ExistsInProjectTable(idforDeleting))
                                            {
                                                projectManager.DeleteProject(idforDeleting);
                                                Console.WriteLine("Successfully Deleted...");   
                                            }
                                        
                                            else
                                            {
                                                Console.WriteLine("No Project Exists with this ID");
                                            }
                                        }
                                    
                                        catch(FormatException e)
                                        {
                                            Console.WriteLine("ID can only in Number");
                                        }
                
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input, Provide Correct Input");
                                        break;
                                }
                            }

                    
                        case "2":

                            while(true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(" ***** EMPLOYEE MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Employee ");
                                Console.WriteLine(" Enter 2 to List All Employees ");
                                Console.WriteLine(" Enter 3 to List Employee By Id ");
                                Console.WriteLine(" Enter 4 to Delete Employee ");
                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                Console.WriteLine("");

                                var EMPId = Console.ReadLine();
                                switch(EMPId)
                                {
                                    case "1":
                                    
                                        tryagain:
                                        
                                            try
                                            {
                                                inputempid:

                                                    Console.WriteLine("Enter the ID of Employee");
                                                    int empId = Convert.ToInt32(Console.ReadLine());
                                                    if (employeeDal.ExistsInEmployeeTable(empId))
                                                    {
                                                        Console.WriteLine("The ID already exists try new ID");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                        
                                                        string empidTry = Console.ReadLine();

                                                        if (empidTry == "x") 
                                                        {
                                                            goto tryagain;
                                                        }       
                                                        
                                                        else
                                                        {
                                                            goto inputempid;
                                                        }
                                                    }
                                            
                                                    Console.WriteLine("Enter Employee Fist Name");
                                                    var fname = Console.ReadLine();
                                                    Console.WriteLine("Enter Employee Last Name");
                                                    var lname = Console.ReadLine();

                                                Email:

                                                    Console.WriteLine("Enter Employee Email ID");
                                                
                                                    var EMAIL= Console.ReadLine();
                                                
                                                    if(!email.IsMatch(EMAIL))
                                                    {
                                                        Console.WriteLine("Invalid Email Format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                
                                                        var emailread=Console.ReadLine();

                                                        if(emailread=="x")
                                                        {
                                                            break;
                                                        }
                                                    
                                                        else
                                                        {
                                                            goto Email;
                                                        }
                                                    }

                                                mobile:

                                                    Console.WriteLine("Enter Employee Mobile Number");
                                                
                                                    var mobile = Console.ReadLine();
                                                
                                                    if(!phonenumber.IsMatch(mobile))
                                                    {
                                                        Console.WriteLine("Invalid Mobile Number format");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                                    
                                                        var mobileread=Console.ReadLine();

                                                        if(mobileread=="x")
                                                        {
                                                            break;
                                                        }
                                                        
                                                        else
                                                        {
                                                            goto mobile;
                                                        }
                                                    }

                                                    Console.WriteLine("Enter Employee Address");
                                                    var address = Console.ReadLine();

                                                roelID : 
                                                    Console.WriteLine("Enter the Id of the Role");
                                                    var roleID = Convert.ToInt32(Console.ReadLine());

                                                    if (roleDal.ExistsInRoleTable(roleID))
                                                    {

                                                        Employee employee1 = new Employee (empId, fname, lname, EMAIL, mobile, address,roleID);
                                                        employeeManager.ToAddEmployee(employee1);                                                                   
                                                        Console.WriteLine("Added Successfully");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This Role Id does not Exist");
                                                        roleDal.ToViewRoleData();
                                                        Console.WriteLine("Above are the Available Roles");
                                                        Console.WriteLine("Enter any key to Try Again");
                                                        Console.WriteLine("Enter  \"x\" to Exit to Main Menu");

                                                        var roleIdRead = Console.ReadLine();

                                                        if (roleIdRead == "x")
                                                        {
                                                            break;
                                                        }
                                                        else 
                                                        {
                                                            goto roelID;
                                                        }
                                                    }
                                            }
                                                    
                                            catch(Exception e)
                                            {
                                                Console.WriteLine("Employee ID should be in Numbers only");
                                            }
                                                
                                            Console.WriteLine("Enter any key to get to Main Menu");
                                            Console.ReadLine();
                                            break;
                    
                                    case "2":
                                        employeeManager.ListAllEmployees();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int searchEmployeeById = Convert.ToInt32(Console.ReadLine());
                                            if (!employeeDal.ExistsInEmployeeTable(searchEmployeeById))
                                            {
                                                Console.WriteLine("Employee Id Does not Exists..");
                                            }
                                            else
                                            {
                                                 employeeManager.ListAllEmployeesById(searchEmployeeById);
                                            }
                                        }

                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("ID can only be in Numbers");
                                        }
                                    
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "4":
                                        try
                                        {
                                            Console.WriteLine("Enter the ID of the Employee");
                                            int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                            if (employeeDal.ExistsInEmployeeTable(idforDeleting))
                                            {
                                                employeeManager.DeleteEmployee(idforDeleting);
                                                Console.WriteLine("Deleted Successfully");
                                                Console.WriteLine("Enter any key to get Main Menu");
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("No found with this Id...");
                                                Console.WriteLine("Enter any key to get Main Menu");
                                                Console.ReadLine();
                                                break;
                                            }
                                        }
                                    
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("Enter Valid Input");
                                        }
                                        break;
                                
                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input, Provide Correct Input");
                                        break;
                                }
                            }

                        case "3":

                            while(true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine(" ***** ROLE MODULE ***** ");
                                Console.WriteLine("");
                                Console.WriteLine(" Enter 1 to Adding Role ");
                                Console.WriteLine(" Enter 2 to List All Roles ");
                                Console.WriteLine(" Enter 3 to List Roles By Id ");
                                Console.WriteLine(" Enter 4 to Delete Role ");
                                Console.WriteLine("Enter  \"x\" to Exit to Main Menu");
                                Console.WriteLine("");

                                var roleSelector = Console.ReadLine();
                                switch (roleSelector)
                                {
                                    case "1":
                                        try
                                        {
                                            inputroleid:

                                                Console.WriteLine("Enter the Role Id");
                                                int role_ID = Convert.ToInt32(Console.ReadLine());
                                                if (roleDal.ExistsInRoleTable(role_ID))
                                                {
                                                    Console.WriteLine("This Role Id Exists...");
                                                    Console.WriteLine("Enter any key to try again");
                                                    Console.WriteLine("Enter \"x\" to get to main menu");

                                                    UserInput = Console.ReadLine();
                                                    if (UserInput == "x")
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        goto inputroleid;
                                                    }

                                                }
                                                Console.WriteLine("Enter the Name of Role");
                                                string role_name = Convert.ToString(Console.ReadLine());

                                                Role newRole = new Role(role_ID, role_name);
                                                roleManager.AddRole(newRole);
                                                Console.WriteLine("Added Successfully!");

                                                Console.WriteLine("Enter any key to get Main Menu");
                                                Console.ReadLine();
                                        }   
                        
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Role ID should be in Numbers only");
                                            Console.ReadLine();
                                        }
                                        break;


                                    case "2":
                                        roleManager.ListAllRoles();
                                        Console.WriteLine("Enter any key to get Main Menu");
                                        Console.ReadLine();
                                        break;

                                    case "3":
                                        try
                                        {
                                            inputroleid1:

                                                Console.WriteLine("Enter the ID of the Role");
                                                int searchRoleById = Convert.ToInt32(Console.ReadLine());
                                                if (!roleDal.ExistsInRoleTable(searchRoleById))
                                                {
                                                    Console.WriteLine("This Role Id Does not Exists...");
                                                    Console.WriteLine("Enter any key to try again");
                                                    Console.WriteLine("Enter \"x\" to get to main menu");
                                                    UserInput = Console.ReadLine();
                                                    if (UserInput == "x")
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        goto inputroleid1;
                                                    }
                                                }
                                                roleManager.ListAllRolesById(searchRoleById);
                                                Console.WriteLine("Enter any key to get Main Menu");
                                                Console.ReadLine();
                                        }

                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("ID should be in Numbers only");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        break; 

                                    case "4":
                                        try
                                        {
                                            deleteRoleById:

                                                Console.WriteLine("Enter the ID of the Role");
                                                int deleteRoleById = Convert.ToInt32(Console.ReadLine());
                                                
                                                if (!roleDal.ExistsInRoleTable(deleteRoleById))
                                                    {
                                                        Console.WriteLine("This Role Id Does not Exists...");
                                                        Console.WriteLine("Enter any key to try again");
                                                        Console.WriteLine("Enter \"x\" to get to main menu");
                                                        UserInput = Console.ReadLine();
                                                        if (UserInput == "x")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            goto deleteRoleById;
                                                        }
                                                    }
                                                    if (roleDal.ExistsRoleInEmployeeTable(deleteRoleById))
                                                    {
                                                        Console.WriteLine("Looks like Employee consists this Role ID, Delete Employee with this Role Id First");
                                                    }
                                                    else
                                                    {
                                                        roleManager.DeleteRole(deleteRoleById);
                                                        Console.WriteLine("Deleted Successfully");
                                                    }

                                                    Console.WriteLine("Enter any key to get Main Menu");
                                                    Console.ReadLine();  
                                        }                                              

                                        catch ( FormatException e)
                                        {
                                            Console.WriteLine("ID should be in Numbers only");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Invalid Input");
                                        }
                                        
                                        break;
                                
                                    case "x":
                                        goto View;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Entry");
                                        break;
                                }
                            }

                        case "S":
                            return;  
                    }

                Console.WriteLine("");
                Console.WriteLine(" ***** HELLO PROLIFICS EMPLOYEE ***** ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 1 to View Project Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 2 to View Employee Module ");
                Console.WriteLine("");
                Console.WriteLine(" Enter 3 to View Role Module");
                Console.WriteLine("");
                Console.WriteLine(" Enter 'S' to QUIT the Application ");
                Console.WriteLine("");
                UserInput = Console.ReadLine();

            }
        }
    }
}







                            

                    
                    
                    
                        
                    
               