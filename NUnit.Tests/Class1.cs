using System;
using PPM.MODEL;
using PPM.DAL;
using PPM.DOMAIN;

namespace Nunit.Tests;

[TestFixture]
public class Tests
{

    [Test]
    public void Test1()
    { 
        ProjectDal projectDal = new ProjectDal();
        Project project = new Project("test", "12/09/2022", "13/09/2023",1);
        int id = 1;
        Assert.True (projectDal.ExistsInProjectTable(id));
    }

    [Test]
    public void Test2()
    { 
        EmployeeDal employeeDal = new EmployeeDal();
        Employee employee = new Employee(2,"sai","laxmi","laxmi@gmail.com","9870675432","D-home",4);
        int employeeId = 2;
        Assert.True (employeeDal.ExistsInEmployeeTable(employeeId));
    }

    [Test]
    public void Test3()
    {
        RoleDal roleDal = new RoleDal(); 
        Role role = new Role(4,"Trinee Software Engineer");
        int roleId = 4;
        Assert.True (roleDal.ExistsInRoleTable(roleId));
    }

    [Test]
    public void AddProject()
    {
        int projectId = 1;
        string projectName = "test";
        string startDate="12/09/2022";
        string endDate = "13/09/2023";
        ProjectDal projectDal = new ProjectDal();
        projectDal.AddToProjectTable(projectId,projectName,startDate,endDate);
    }

    [Test]
    public void AddEmployee()
    {
        int employeeId = 1;
        string firstName = "shoba";
        string lastName = "mandlole";
        string email = "shoba@gmail.com";
        string mobileNumber = "9182288888";
        string address = "home";
        int roleID = 2;
        EmployeeDal employeeDal =  new EmployeeDal();
        employeeDal.AddToEmployeeTable(employeeId,firstName,lastName,email,mobileNumber,address,roleID);       
    }

    [Test]
    public void AddRole()
    {
        int roleId=1;
        string roleName="Technical Lead";
        RoleDal roleDal = new RoleDal();
        roleDal.AddToRoleTable(roleId,roleName);
    }
}