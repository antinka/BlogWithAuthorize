using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Infrastructure;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

namespace BlogUsingEF.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            //Find if login unic.
            ApplicationUser user = await Database.ApplicationUserManager.FindByEmailAsync(userDto.UserName);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
                //Add new user.
                var result = await Database.ApplicationUserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // Add role to current user.
                await Database.ApplicationUserManager.AddToRoleAsync(user.Id, userDto.Role);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // Find user by name and password.
            ApplicationUser user = await Database.ApplicationUserManager.FindAsync(userDto.UserName, userDto.Password);
            // Autorize and return claim.
            if (user != null)
                claim = await Database.ApplicationUserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.ApplicationRoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.ApplicationRoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
