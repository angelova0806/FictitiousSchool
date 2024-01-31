using FictitiousSchool.Models;

namespace FictitiousSchool.Interfaces
{
    public interface IApplicationService
    {
        Task<CommonModel.TransactionStatus> GetApplicationsListAsync();
        Task<CommonModel.TransactionStatus> SaveApplicationAsync(Application model);

    }
}
