using FictitiousSchool.Context;
using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace FictitiousSchool.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task AddApplicationAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        Task<IEnumerable<Application>> IApplicationRepository.GetAllApplicationsAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}
