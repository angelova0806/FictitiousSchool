using FictitiousSchool.Context;
using FictitiousSchool.Models;
using FictitiousSchool.Repository;
using Microsoft.EntityFrameworkCore;

namespace FictitiousSchool.Tests
{
    public class ParticipantRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public ParticipantRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "FictitiousSchoolTestDb")
                .Options;
        }

        [Fact]
        public async Task AddParticipantsAsync_AddsParticipantsCorrectly()
        {
            // Arrange
            var participants = new List<Participants>
        {
            new Participants { ParticipantId = 1, ApplicationId = 1, Name = "John Doe", Phone = "1234567890", Email = "john@example.com" },
            new Participants { ParticipantId = 2, ApplicationId = 1, Name = "Jane Doe", Phone = "0987654321", Email = "jane@example.com" }
        };

            // Act
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                var repository = new ParticipantRepository(context);
                await repository.AddParticipantsAsync(participants);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                Assert.Equal(participants.Count, context.Participants.Count());
                // Additional assertions as needed, such as verifying if data is as expected
                var participant1 = context.Participants.FirstOrDefault(p => p.ParticipantId == 1);
                Assert.NotNull(participant1);
                Assert.Equal("John Doe", participant1.Name);
                Assert.Equal("1234567890", participant1.Phone);
                Assert.Equal("john@example.com", participant1.Email);
                Assert.Equal(1, participant1.ApplicationId);

                var participant2 = context.Participants.FirstOrDefault(p => p.ParticipantId == 2);
                Assert.NotNull(participant2);
                Assert.Equal("Jane Doe", participant2.Name);
                Assert.Equal("0987654321", participant2.Phone);
                Assert.Equal("jane@example.com", participant2.Email);
                Assert.Equal(1, participant2.ApplicationId);
            }
        }
    }
}
