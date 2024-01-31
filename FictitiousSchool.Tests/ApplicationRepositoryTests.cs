using FictitiousSchool.Context;
using FictitiousSchool.Models;
using FictitiousSchool.Repository;
using Microsoft.EntityFrameworkCore;


namespace FictitiousSchool.Tests
{
    public class ApplicationRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public ApplicationRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "FictitiousSchoolDb")
                .Options;
        }

        [Fact]
        public async Task GetAllApplicationsAsync_ReturnsAllApplications()
        {
            // Arrange
            await using var context = new ApplicationDbContext(_dbContextOptions);
            context.Applications.Add(new Application());
            context.Applications.Add(new Application());
            await context.SaveChangesAsync();

            var repository = new ApplicationRepository(context);

            // Act
            var applications = await repository.GetAllApplicationsAsync();

            // Assert
            Assert.Equal(2, applications.Count());
        }

        [Fact]
        public async Task AddApplicationAsync_AddsAnApplication()
        {
            // Arrange
            var application = new Application();
            await using var context = new ApplicationDbContext(_dbContextOptions);
            var repository = new ApplicationRepository(context);

            // Act
            await repository.AddApplicationAsync(application);
            await repository.SaveChangesAsync();

            // Assert
            var addedApplication = context.Applications.FirstOrDefault();
            Assert.NotNull(addedApplication);
        }
    }
}
