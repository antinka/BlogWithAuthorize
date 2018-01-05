using BlogUsingEF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.DAL.Interfaces;
using AutoMapper;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Repositories;

namespace BlogUsingEF.BLL.Services
{
   public class UserService : IUserServicesAddEnter
    {

        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        //return all users from db
        public IEnumerable<UserDTO> GetUsers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetList());
        }
        // take user by id
        public UserDTO GetUsersById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            IMapper mapper = config.CreateMapper();
            UserDTO userDTO = mapper.Map<User, UserDTO>(Database.Users.GetById(id));
            return userDTO;
        }
        //add new user
        public UserDTO AddNewUser(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            try
            {
                var ifExistUserName = (from b in Database.Users.GetList() where b.UserName == user.UserName select b).Count();
                if (ifExistUserName == 0)
                {
                    Database.Users.Create(user);
                    Database.Users.Save();
                    userDTO.Id = user.Id;
                    return userDTO;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        // check if this user esist in db and if so then return they data
        public UserDTO EnterToSystem(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            try
            {
                var detailsUser= Database.Users.GetList().Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (detailsUser!= null)
                {
                    userDTO.Id = detailsUser.Id;
                    return userDTO;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
