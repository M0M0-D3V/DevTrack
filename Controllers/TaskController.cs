using AutoMapper;
using DevTrack.Entities;
using DevTrack.Helpers;
using DevTrack.Models.Tasks;
using DevTrack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevTrack.Controllers
{
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private ITaskService _taskService;
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
        public TaskController(
            ITaskService taskService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _taskService = taskService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet("new")]
        public IActionResult New(NewTaskModel task)
        {
            if (isLoggedIn)
            {
                return View("New", task);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost("create")]
        public IActionResult Create([FromForm] NewTaskModel model)
        {
            model.UserId = (int)HttpContext.Session.GetInt32("UserId");
            model.ProjectId = (int)HttpContext.Session.GetInt32("ProjectId");
            var task = _mapper.Map<Task>(model);
            try
            {
                _taskService.Create(task);
                return RedirectToAction("Info", "Project", new { id = model.ProjectId });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}