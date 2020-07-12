using System.Collections.Generic;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IUsersInRoles
    {
        bool AssignRole(UsersInRoles usersInRoles);
        bool CheckRoleExists(UsersInRoles usersInRoles);
        bool RemoveRole(UsersInRoles usersInRoles);
        List<AssignRolesViewModel> GetAssignRoles();
    }
}