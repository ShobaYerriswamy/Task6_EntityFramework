using System;
using PPM.MODEL;
using PPM.DAL;
using IEntityOperation;


namespace PPM.DOMAIN;

public class ProjectManager : IEntityOperationProject 
{
    ProjectDal projectDal = new ProjectDal();

    public void AddProject (Project project)
    {
        projectDal.AddToProjectTable(project.id, project.projectName, project.startDate, project.endDate);
    } 

    public void ListAllProjects ()
    {
        projectDal.ToViewProjectData();
    }

    public void ListAllProjectsById (int projectId)
    {
        projectDal.ViewProjectDataById(projectId);
    }

    public void DeleteProject (int projectId)
    {
        projectDal.DeleteProjectFromTable(projectId);
    }

    public void ViewAllEmployeesInProjectById(int projectId)
    {
        projectDal.DisplayAllEmployeesInProjectById(projectId);
    }

    public void AddEmployeesToProject (int projectId, int employeeId)
    {
        projectDal.AddEmployeesToProject(projectId, employeeId);
    }

    public void DeleteEmployeesFromProject (int projectId, int employeeId)
    {
        projectDal.DeleteEmployeesFromProject(projectId, employeeId);
    }

    public void ViewAllProjects()
    {
        throw new NotImplementedException();
    }

    public void ViewAllProjectsById(int projectId)
    {
        throw new NotImplementedException();
    }

    public void AddEmployeeToProject(int projectId, int employeeId)
    {
        throw new NotImplementedException();
    }

    public void DeleteEmployeeFromProject(int projectId, int employeeId)
    {
        throw new NotImplementedException();
    }
}
