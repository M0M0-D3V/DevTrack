using AutoMapper;
using DevTrack.Entities;
using DevTrack.Helpers;
using DevTrack.Models.Orgs;
using DevTrack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevTrack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private IOrganizationService _organizationService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public OrganizationController(
            IOrganizationService organizationService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _organizationService = organizationService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpPost("neworg")]
        public IActionResult NewOrg([FromForm] OrganizationModel model)
        {
            var org = _mapper.Map<Organization>(model);

            try
            {
                // create org
                _organizationService.Create(org);
                return RedirectToAction("Dashboard", "Home");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}