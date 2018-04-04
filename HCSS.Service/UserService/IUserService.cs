using System.Collections.Generic;
using HCSS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HCSS.Service.UserService
{
    public interface IUserService
    {
        //检查用户名是否存在
        bool CheckUserNameExist(string userName);

        //根据用户名获取用户信息
        User GetByUserName(string userName);

        //注册用户
        bool InsertUser(User user);

        //更新用户信息
        bool UpdateUser(User user);
    }
}