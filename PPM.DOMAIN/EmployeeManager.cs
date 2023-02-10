using System;
using PPM.MODEL;
using PPM.DAL;
using IEntityOperation;

namespace PPM.DOMAIN;

public class EmployeeManager : IEntityOperationEmployee
{
    EmployeeDal employeeDal = new EmployeeDal();

    public void ToAddEmployee (Employee employee)
    {
        employeeDal.AddToEmployeeTable (employee.employeeID, employee.employeefirstName, employee.lastName, employee.email, employee.mobile, employee.address ,employee.roleId);
    }

    public void ListAllEmployees()
    {
        employeeDal.ToViewEmployeeData();
    }

    public void ListAllEmployeesById (int employeeId)
    {
        employeeDal.ViewEmployeeDataById(employeeId);
    }

    public void DeleteEmployee(int employeeId)
    {
        employeeDal.DeleteEmployeeFromTable(employeeId);
    }
}
