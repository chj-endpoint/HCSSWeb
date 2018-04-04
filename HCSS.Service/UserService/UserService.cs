using Microsoft.EntityFrameworkCore;
using HCSS.Model.Entity;
using System.Collections.Generic;
using System;

namespace HCSS.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork mUnitWork;
        public UserService(IUnitOfWork iUnitWork){
            mUnitWork = iUnitWork;
        }

        public bool CheckUserNameExist(string userName)
        {
            var repoUser = mUnitWork.GetRepository<User>();
            int count = repoUser.Count(predicate : u => u.UserName == userName);
            return count > 0;
        }

        public User GetByUserName(string userName)
        {
            var repoUser = mUnitWork.GetRepository<User>();
            User user = repoUser.GetFirstOrDefault(predicate : u => u.UserName == userName);
            return user;
        }

        public bool InsertUser(User user)
        {
            var repoUser = mUnitWork.GetRepository<User>();
            repoUser.Insert(user);
            int rows = mUnitWork.SaveChanges();
            return rows > 0;
        }

        public bool UpdateUser(User user)
        {
            var repoUser = mUnitWork.GetRepository<User>();
            User userDb = repoUser.GetFirstOrDefault(predicate : u => u.UserName == user.UserName);
            if (userDb == null) return false;
            if(!string.IsNullOrEmpty(user.Name)){
                userDb.Name = user.Name;
            }
            if(!string.IsNullOrEmpty(user.Password)){
                userDb.Password = user.Password;
            }
            if(!string.IsNullOrEmpty(user.Phone)){
                userDb.Phone = user.Phone;
            }
            if(user.Role > 0){
                userDb.Role = user.Role;
            }
            userDb.UpdateTime = System.DateTime.Now;
            repoUser.Update(userDb);
            int rows = mUnitWork.SaveChanges();
            return rows > 0;
        }
    }
}