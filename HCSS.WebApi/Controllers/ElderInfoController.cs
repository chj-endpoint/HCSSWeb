
using System.Collections.Generic;
using HCSS.Model.Entity;
using HCSS.Service.ElderInfoService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HCSS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ElderInfoController
    {
        private IElderInfoService mElderInfoService;
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
            string result = JsonConvert.SerializeObject(elderInfo);
            return result;
        }

        [HttpGet]
        public string GetById(int id)
        {
            ElderInfo elderInfo = new ElderInfo();
            elderInfo = mElderInfoService.GetElderInfoById(id);
            string result = JsonConvert.SerializeObject(elderInfo);
            return result;
        }

        [HttpGet]
        public string GetByCondition(int pageIndex, int pageSize, string street, string community, string village, string name)
        {           
            var pagedList = mElderInfoService.GetElderInfoByCondition(pageIndex, pageSize, street, community, village, name);
            List<ElderInfo> elderList = (List<ElderInfo>)pagedList.Items;
            string result = JsonConvert.SerializeObject(elderList);
            return result;
        }
    }
}