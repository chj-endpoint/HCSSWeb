
using System.Collections.Generic;
using HCSS.Model.Entity;
using HCSS.Service.ElderInfoService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HCSS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ElderInfoController
    {
        private IElderInfoService mElderInfoService;
        IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
        public ElderInfoController(IElderInfoService elderInfoService)
        {
            mElderInfoService = elderInfoService;
        }

        // GET api/ElderInfo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            ElderInfo elderInfo = new ElderInfo();
            elderInfo = mElderInfoService.GetElderInfoById(id);
            string result = JsonConvert.SerializeObject(elderInfo, Formatting.Indented, timeConverter);
            return result;
        }

        [HttpGet]
        public string GetById(int id)
        {
            ElderInfo elderInfo = new ElderInfo();
            elderInfo = mElderInfoService.GetElderInfoById(id);
            string result = JsonConvert.SerializeObject(elderInfo, Formatting.Indented, timeConverter);
            return result;
        }

        [HttpGet]
        public string GetByCondition(int pageIndex, int pageSize, string street, string community, string village, string name)
        {           
            var pagedList = mElderInfoService.GetElderInfoByCondition(pageIndex, pageSize, street, community, village, name);
            List<ElderInfo> elderList = (List<ElderInfo>)pagedList.Items;
            string result = JsonConvert.SerializeObject(elderList, Formatting.Indented, timeConverter);
            return result;
        }

        [HttpPost]
        public string UpdateElder([FromBody] ElderInfo elderInfo)
        {           
            elderInfo.updateTime = System.DateTime.Now;
            bool updateResult = mElderInfoService.Update(elderInfo);
            var result = new { isOk = updateResult, message = string.Empty };            
            return JsonConvert.SerializeObject(result);
        }

         [HttpPost]
        public string InsertElder([FromBody] ElderInfo elderInfo)
        {           
            elderInfo.createTime = System.DateTime.Now;
            elderInfo.updateTime = System.DateTime.Now;
            bool insertResult = mElderInfoService.Insert(elderInfo);
            var result = new { isOk = insertResult, message = string.Empty };            
            return JsonConvert.SerializeObject(result);
        }
    }
}