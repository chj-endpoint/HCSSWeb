using HCSS.Model.Entity;

namespace HCSS.Service.ElderInfoService
{
    public interface IElderInfoService
    {
        ElderInfo GetElderInfoById(int id);
    }
}