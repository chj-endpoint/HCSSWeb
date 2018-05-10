using System.Collections.Generic;
using HCSS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HCSS.Service.ElderInfoService
{
    public interface IElderInfoService
    {
        //根据id查询
        ElderInfo GetElderInfoById(int id);

        //查询条件
        IPagedList<ElderInfo> GetElderInfoByCondition(int pageIndex, int pageSize, string street, string community, string village, string name);
        bool Update(ElderInfo elderInfo);
        bool Insert(ElderInfo elderInfo);
    }
}