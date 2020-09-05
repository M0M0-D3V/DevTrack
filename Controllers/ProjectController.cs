using AutoMapper;
using DevTrack.Entities;
using DevTrack.Helpers;
using DevTrack.Models.Projects;
using DevTrack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevTrack.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }
        public ProjectController(
            IProjectService projectService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _projectService = projectService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet("new")]
        public IActionResult New(NewProjectModel project)
        {
            if (isLoggedIn)
            {
                return View("New", project);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost("create")]
        public IActionResult Create([FromForm] NewProjectModel model)
        {
            model.UserId = (int)HttpContext.Session.GetInt32("UserId");
            var project = _mapper.Map<Project>(model);
            try
            {
                {
                    _projectService.Create(project);
                    return RedirectToAction("Dashboard", "Home", model.UserId);
                }
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}