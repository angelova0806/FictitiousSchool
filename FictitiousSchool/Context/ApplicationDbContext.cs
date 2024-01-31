using FictitiousSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace FictitiousSchool.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Participants> Participants { get; set; }

    }
}
