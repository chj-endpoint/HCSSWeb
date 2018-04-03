using Microsoft.EntityFrameworkCore;
using HCSS.Model.Entity;
using System.Collections.Generic;
using System;

namespace HCSS.Service.ElderInfoService
{
    public class ElderInfoService : IElderInfoService
    {
        private readonly IUnitOfWork mUnitWork;
        public ElderInfoService(IUnitOfWork iUnitWork){
            mUnitWork = iUnitWork;
        }

        public IPagedList<ElderInfo> GetElderInfoByCondition(int pageIndex, int pageSize, string street, string community, string village, string name)
        {
            var repoElder = mUnitWork.GetRepository<ElderInfo>();    
            
            Predicate<ElderInfo> predicate = delegate(ElderInfo elderInfo){
                bool condition = true;
                if(condition && !string.IsNullOrEmpty(street)){
                    condition = string.Equals(elderInfo.Street, street);
                }
                if(condition && !string.IsNullOrEmpty(community)){
                    condition = string.Equals(elderInfo.Community, community);
                }
                if(condition && !string.IsNullOrEmpty(village)){
                    condition = string.Equals(elderInfo.Village, village);
                }
                if(condition && !string.IsNullOrEmpty(name)){
                    condition = elderInfo.Name.Contains(name);
                }
                return condition;
            };

            var pagedList = repoElder.GetPagedList(predicate : c => predicate(c), pageIndex: pageIndex, pageSize: pageSize);
            // pagedList = repoElder.GetPagedList(predicate : b => b.Community == "ddd", pageIndex: pageIndex, pageSize: pageSize);
            return pagedList;
        }

        private bool FindPredicate(ElderInfo obj)
        {
            throw new NotImplementedException();
        }

        public ElderInfo GetElderInfoById(int id){
            var repoElder = mUnitWork.GetRepository<ElderInfo>();            
            ElderInfo elderInfo = repoElder.Find(id);

            return elderInfo;
        }
    }
}