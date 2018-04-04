
using System.Collections.Generic;
using HCSS.Model.Entity;
using HCSS.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HCSS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController
    {
        private IUserService mUserService;
        public UserController(IUserService userService)
        {
            mUserService = userService;
        }

        [HttpGet]
        public bool IsExistUser(string userName)
        {            
            bool isExist = mUserService.CheckUserNameExist(userName);
            return isExist;
        }

        [HttpGet]
        public string GetByName(string userName)
        {           
            User user = mUserService.GetByUserName(userName);
            string result = JsonConvert.SerializeObject(user);
            return result;
        }

        [HttpPost]
        public string Insert([FromBody] User user)
        {                       
            user.CreateTime = System.DateTime.Now;
            user.UpdateTime = System.DateTime.Now;
            if(user.Role <= 0){
                user.Role = 1;
            }
            bool insertResult = mUserService.InsertUser(user);
            var result = new { isOk = insertResult, message = string.Empty };
            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Update([FromBody] User user)
        {           
            user.UpdateTime = System.DateTime.Now;
            bool updateResult = mUserService.UpdateUser(user);
            var result = new { isOk = updateResult, message = string.Empty };            
            return JsonConvert.SerializeObject(result);
        }
    }
}