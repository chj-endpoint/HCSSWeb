
using HCSS.Model.Entity;
using HCSS.Service.ElderInfoService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HCSS.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ElderInfoController
    {
        private IElderInfoService mElderInfoService;
        public ElderInfoController(IElderInfoService elderInfoService)
        {
            mElderInfoService = elderInfoService;
        }

        // GET api/ElderInfo/5
        [HttpGet]
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

        // GET api/ElderInfo/5
        [HttpGet]
        public string GetByName(string street, string community, string village, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException("message", nameof(name));
            }

            return "value";
        }
    }
}