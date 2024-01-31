using FictitiousSchool.Controllers;
using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace FictitiousSchool.Tests
{
    public class HomeControllerTests
    {
        private readonly Mock<IApplicationService> _mockApplicationService;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockApplicationService = new Mock<IApplicationService>();
            _controller = new HomeController(_mockApplicationService.Object);
        }

        [Fact]
        public async Task GetApplicationsList_ReturnsOkObjectResultWithStatus()
        {
            var expectedApplications = new List<Application>
        {
            new Application { ApplicationId = 1, CourseId = 101, CourseDate = DateTime.Now, CompanyName = "Company A", CompanyPhone = "1234567890", CompanyEmail = "contact@companya.com" },
            new Application { ApplicationId = 2, CourseId = 102, CourseDate = DateTime.Now.AddDays(1), CompanyName = "Company B", CompanyPhone = "0987654321", CompanyEmail = "contact@companyb.com" }
        };
            var fakeStatus = new CommonModel.TransactionStatus { IsSuccess = true, data = expectedApplications };
            _mockApplicationService.Setup(service => service.GetApplicationsListAsync()).ReturnsAsync(fakeStatus);

            var result = await _controller.GetApplicationsList();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);

            var jsonResponse = JsonConvert.SerializeObject(okResult.Value);
            var resultValue = JsonConvert.DeserializeObject<Dictionary<string, CommonModel.TransactionStatus>>(jsonResponse);
            Assert.NotNull(resultValue);
            Assert.True(resultValue.ContainsKey("status"));

            var status = resultValue["status"];
            Assert.NotNull(status);
            Assert.Equal(fakeStatus.IsSuccess, status.IsSuccess);

            var applications = JsonConvert.DeserializeObject<List<Application>>(JsonConvert.SerializeObject(status.data));
            Assert.NotNull(applications);
            Assert.Equal(expectedApplications.Count, applications.Count);

            for (int i = 0; i < expectedApplications.Count; i++)
            {
                Assert.Equal(expectedApplications[i].ApplicationId, applications[i].ApplicationId);
                Assert.Equal(expectedApplications[i].CourseId, applications[i].CourseId);
                Assert.Equal(expectedApplications[i].CourseDate, applications[i].CourseDate);
                Assert.Equal(expectedApplications[i].CompanyName, applications[i].CompanyName);
                Assert.Equal(expectedApplications[i].CompanyPhone, applications[i].CompanyPhone);
                Assert.Equal(expectedApplications[i].CompanyEmail, applications[i].CompanyEmail);
            }
        }
    

    [Fact]
        public async Task SaveData_ReturnsOkResultWithStatus()
        {
            // Arrange
            var application = new Application(); // Populate with necessary data
            var fakeStatus = new CommonModel.TransactionStatus { IsSuccess = true };
            _mockApplicationService.Setup(service => service.SaveApplicationAsync(application))
                .ReturnsAsync(fakeStatus);

            // Act
            var result = await _controller.SaveData(application);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CommonModel.TransactionStatus>(okResult.Value);
            Assert.Equal(fakeStatus, returnValue);
        }
    }
}
