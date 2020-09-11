using System.Collections.Generic;
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
            model.WorkspaceId = (int)HttpContext.Session.GetInt32("WorkspaceId");
            var project = _mapper.Map<Project>(model);
            try
            {
                _projectService.Create(project);
                return RedirectToAction("Info", "Workspace", new { id = model.WorkspaceId });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAll();
            var model = _mapper.Map<IList<ProjectModel>>(projects);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Info(int id)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            var thisProject = _projectService.GetById(id);
            var model = _mapper.Map<ProjectModel>(thisProject);
            HttpContext.Session.SetInt32("ProjectId", id);
            return View("Info", model);
        }
    }
}