using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;
using FictitiousSchool.Services;
using Moq;

namespace FictitiousSchool.Tests
{
    public class ApplicationServiceTests
    {
        private readonly Mock<IApplicationRepository> _mockApplicationRepo;
        private readonly Mock<IParticipantRepository> _mockParticipantRepo;
        private readonly ApplicationService _applicationService;

        public ApplicationServiceTests()
        {
            _mockApplicationRepo = new Mock<IApplicationRepository>();
            _mockParticipantRepo = new Mock<IParticipantRepository>();
            _applicationService = new ApplicationService(_mockApplicationRepo.Object, _mockParticipantRepo.Object);
        }

        [Fact]
        public async Task GetApplicationsListAsync_ReturnsAllApplications()
        {
            // Arrange
            var applications = new List<Application> { new Application(), new Application() };
            _mockApplicationRepo.Setup(repo => repo.GetAllApplicationsAsync()).ReturnsAsync(applications);

            // Act
            var result = await _applicationService.GetApplicationsListAsync();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(applications, result.data);
        }

        [Fact]
        public async Task SaveApplicationAsync_SavesValidApplication()
        {
            // Arrange
            var application = new Application { lstParticipants = new List<Participants> { new Participants() } };
            _mockApplicationRepo.Setup(repo => repo.AddApplicationAsync(application)).Verifiable();
            _mockParticipantRepo.Setup(repo => repo.AddParticipantsAsync(application.lstParticipants)).Verifiable();
            _mockApplicationRepo.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _applicationService.SaveApplicationAsync(application);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(application.ApplicationId, result.data);
            _mockApplicationRepo.Verify();
            _mockParticipantRepo.Verify();
        }

        [Fact]
        public async Task SaveApplicationAsync_ReturnsErrorWhenNoParticipants()
        {
            // Arrange
            var application = new Application { lstParticipants = new List<Participants>() };

            // Act
            var result = await _applicationService.SaveApplicationAsync(application);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Please add at least one participant", result.message);
        }
    }
}

    