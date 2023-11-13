using BusinessObject.Model.Authen;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Authenticate(UserLogin login) => UserDAO.GetUser(login);

        public void CreateUser(User user) => UserDAO.AddUser(user);

        public void DeleteUser(User user) => UserDAO.DeleteUser(user);

        public User GetUserById(Guid id) => UserDAO.GetUserByUid(id);

        public void UpdateUser(Guid id, User user) => UserDAO.UpdateUser(id, user);
    }
}
