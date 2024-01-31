
using FictitiousSchool.Models;

namespace FictitiousSchool.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task AddApplicationAsync(Application application);
        Task<int> SaveChangesAsync();        
    }
}