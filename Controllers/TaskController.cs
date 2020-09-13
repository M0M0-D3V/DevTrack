using AutoMapper;
using DevTrack.Helpers;
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
    }
}