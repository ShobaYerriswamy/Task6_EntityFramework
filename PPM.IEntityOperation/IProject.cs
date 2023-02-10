using PPM.DAL;
using PPM.MODEL;

namespace IEntityOperation
{
    public interface IEntityOperationProject
    {
        void AddProject (Project project);
        void ViewAllProjects ();
        void ViewAllProjectsById (int projectId);
        void DeleteProject (int projectId);
        void AddEmployeeToProject (int projectId, int employeeId);
        void DeleteEmployeeFromProject (int projectId, int employeeId);
    }
}
