using BlogUsingEF.BLL.DTO;
using BlogUsingEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.BLL.Interfaces
{
    public interface IUserServicesAddEnter
    {
       IEnumerable<UserDTO> GetUsers();
        UserDTO GetUsersById(int id);
       UserDTO AddNewUser(UserDTO userDTO);
       UserDTO EnterToSystem(UserDTO userDTO);
    }
}
