using BusinessObject.Context;
using BusinessObject.Model;
using BusinessObject.Model.Authen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        //GET USER
        public static User GetUser(UserLogin login)
        {
            var user = new User();
            try
            {
                using (var ctx = new eStoreDBContext())
                {
                    user = ctx.Users.FirstOrDefault(o => o.UserName == login.UserName && o.Password == login.Password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        //ADD USER
        public static void AddUser(User user)
        {
            try
            {
                using (var ctx = new eStoreDBContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET USER BY ID
        public static User GetUserByUid(Guid id)
        {
            var user = new User();
            try
            {
                using (var ctx = new eStoreDBContext())
                {
                    user = ctx.Users.FirstOrDefault(o => o.UserId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        //UPDATE USER
        public static void UpdateUser(Guid id, User user)
        {
            try
            {
                using (var ctx = new eStoreDBContext())
                {
                    if (GetUserByUid(id) != null)
                    {
                        ctx.Users.Add(user);
                        ctx.Entry(user).State = 
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //DELETE USER
        public static void DeleteUser(User user)
        {
            try
            {
                using (var ctx = new eStoreDBContext())
                {
                    var p1 = ctx.Users.SingleOrDefault(
                        x => x.UserId == user.UserId);
                    ctx.Users.Remove(p1);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
