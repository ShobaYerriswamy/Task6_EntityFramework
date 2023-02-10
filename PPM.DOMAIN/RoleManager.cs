using System;
using PPM.MODEL;
using PPM.DAL;
using IEntityOperation;

namespace PPM.DOMAIN;

public class RoleManager : IEntityOperationRole
{
    RoleDal roleDal = new RoleDal();

    public void AddRole (Role role)
    {
        roleDal.AddToRoleTable(role.roleId, role.roleName);
    }

    public void ListAllRoles ()
    {
        roleDal.ToViewRoleData();
    }

    public void ListAllRolesById (int roleId)
    {
        roleDal.ViewRoleDataById(roleId);
    }

    public void DeleteRole (int roleId)
    {
        roleDal.DeleteRoleFromTable (roleId);
    }

    public void ListAllRole()
    {
        throw new NotImplementedException();
    }
}
