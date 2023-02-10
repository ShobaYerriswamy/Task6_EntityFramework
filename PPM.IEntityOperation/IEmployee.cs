using PPM.DAL;
using PPM.MODEL;

namespace IEntityOperation
{
    public interface IEntityOperationEmployee
    {
        void ToAddEmployee (Employee employee);
        void ListAllEmployees();
        void ListAllEmployeesById (int employeeId);
        void DeleteEmployee(int employeeId);
    }
}

