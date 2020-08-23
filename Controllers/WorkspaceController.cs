using AutoMapper;
using DevTrack.Entities;
using DevTrack.Helpers;
using DevTrack.Models.Users;
using DevTrack.Models.Workspaces;
using DevTrack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevTrack.Controllers
{
    // [Authorize]
    // [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : Controller
    {
        private IWorkspaceService _workspaceService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public WorkspaceController(
            IWorkspaceService workspaceService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _workspaceService = workspaceService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        // [HttpGet("new")]
        // public IActionResult New(UserModel uid)
        // {
        //     return View("New", uid);
        // }
        [HttpPost("create")]
        public IActionResult Create([FromForm] WorkspaceModel model)
        {
            model.UserId = (int)HttpContext.Session.GetInt32("UserId");
            var work = _mapper.Map<Workspace>(model);
            try
            {
                // create workspace
                _workspaceService.Create(work);
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
