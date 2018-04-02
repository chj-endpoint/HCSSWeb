
using HCSS.Service.ElderInfoService;
using Microsoft.AspNetCore.Mvc;


namespace HCSS.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ElderInfoController
    {
        private ElderInfoService mElderInfoService;
        public ElderInfoController(ElderInfoService elderInfoService)
        {
            mElderInfoService = elderInfoService;
        }

        // GET api/ElderInfo/5
        [HttpGet("{id}")]
        public string QueryById(int id)
        {
            return "value";
        }

        // GET api/ElderInfo/5
        [HttpGet("{street, community, village, name}")]
        public string Query(string street, string community, string village, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException("message", nameof(name));
            }

            return "value";
        }
    }
}