using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FictitiousSchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public HomeController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [EnableCors("OurPolicyNew")]
        [HttpGet, Route("GetApplicationsList")]
        public async Task<IActionResult> GetApplicationsList()
        {
            var status = await _applicationService.GetApplicationsListAsync();
            return Ok(new { status = status });
        }

        [HttpPost, Route("SaveData")]
        [DisableCors]
        public async Task<IActionResult> SaveData(Application model)
        {
            var status = await _applicationService.SaveApplicationAsync(model);
            return Ok(status);
        }
    }


}
