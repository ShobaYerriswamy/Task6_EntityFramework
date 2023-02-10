using System;
namespace PPM.MODEL;

public class Employee
{
    public int employeeID {get; set;}

    public string employeefirstName{get;set;}
    public string lastName {get; set;} 
    public string email {get; set;} 
    public string mobile {get; set;} 
    public string address {get; set;} 
    public int roleId {get; set;} 
       

    public Employee(int employeeid, string FirstName, string LastName, string Email, string Mobile, string Address, int RoleID)
    {
        this.employeeID = employeeid;  
        this.employeefirstName = FirstName;
        this.lastName = LastName;
        this.email = Email;
        this.mobile = Mobile;
        this.address = Address;
        this.roleId = RoleID;
           
    }

    public Employee ()
    {

    }

}
