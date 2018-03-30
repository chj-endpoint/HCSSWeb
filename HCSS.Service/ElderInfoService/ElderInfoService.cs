using Microsoft.EntityFrameworkCore;
using HCSS.Model.Entity;

namespace HCSS.Service.ElderInfoService
{
    public class ElderInfoService : IElderInfoService
    {
        private readonly IUnitOfWork mUnitWork;
        public ElderInfoService(IUnitOfWork iUnitWork){
            mUnitWork = iUnitWork;
        }

        public ElderInfo GetElderInfoById(int id){
            var repoElder = mUnitWork.GetRepository<ElderInfo>();
            
            ElderInfo elderInfo = repoElder.Find(id);

            return elderInfo;
        }


    }
}