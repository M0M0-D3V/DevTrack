using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevTrack.Models.Users;
using DevTrack.Models.Workspaces;
using DevTrack.Models;
using DevTrack.Services;
using DevTrack.Controllers;
using System.Net.Http;
using AutoMapper;
using DevTrack.Helpers;
using Microsoft.Extensions.Options;

namespace DevTrack.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IWorkspaceService _workspaceService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<HomeController> _logger;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        public HomeController(IUserService userService, IWorkspaceService workspaceService, IMapper mapper, IOptions<AppSettings> appSettings, ILogger<HomeController> logger)
        {
            _userService = userService;
            _workspaceService = workspaceService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            if (isLoggedIn)
            {
                int userId = (int)uid;
                // var user = UsersController().GetById(userId);

                return RedirectToAction("Dashboard", new { userId = (int)uid });
            }
            return View("Index");
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard(UserModel user)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            var AllWorkspaces = _workspaceService.GetAll();
            ViewBag.AllWorkspaces = AllWorkspaces;
            return View("Dashboard", user);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        // [HttpGet("workspace/new")]
        // public IActionResult NewWorkspace(UserModel user)
        // {
        //     if (isLoggedIn)
        //     {

        //         return View("NewWorkspace", user.UserId);
        //     }
        //     return View("Index");
        // }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
