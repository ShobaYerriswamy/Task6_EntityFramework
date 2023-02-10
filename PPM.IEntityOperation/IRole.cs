using PPM.DAL;
using PPM.MODEL;

namespace IEntityOperation
{
    public interface IEntityOperationRole
    {
        void AddRole (Role role);
        void ListAllRole ();
        void ListAllRolesById (int roleId);
        void DeleteRole (int roleId);
    } 
}


