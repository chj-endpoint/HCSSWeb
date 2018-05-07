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

        //分页查询老人信息
        public IPagedList<ElderInfo> GetElderInfoByCondition(int pageIndex, int pageSize, string street, string community, string village, string name)
        {
            var repoElder = mUnitWork.GetRepository<ElderInfo>();    
            //查询预测
            Predicate<ElderInfo> predicate = delegate(ElderInfo elderInfo){
                bool condition = true;
                if(condition && !string.IsNullOrEmpty(street)){
                    condition = string.Equals(elderInfo.street, street);
                }
                if(condition && !string.IsNullOrEmpty(community)){
                    condition = string.Equals(elderInfo.community, community);
                }
                if(condition && !string.IsNullOrEmpty(village)){
                    condition = string.Equals(elderInfo.village, village);
                }
                if(condition && !string.IsNullOrEmpty(name)){
                    condition = elderInfo.name.Contains(name);
                }
                return condition;
            };

            var pagedList = repoElder.GetPagedList(predicate : c => predicate(c), pageIndex: pageIndex, pageSize: pageSize);
            // pagedList = repoElder.GetPagedList(predicate : b => b.Community == "ddd", pageIndex: pageIndex, pageSize: pageSize);
            return pagedList;
        }

        //根据id查询老人信息
        public ElderInfo GetElderInfoById(int id){
            var repoElder = mUnitWork.GetRepository<ElderInfo>();            
            ElderInfo elderInfo = repoElder.Find(id);

            return elderInfo;
        }
    }
}