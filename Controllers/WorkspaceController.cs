using System;
using System.Collections.Generic;
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
        private IUserService _userService;
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

        public WorkspaceController(
            IWorkspaceService workspaceService,
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _workspaceService = workspaceService;
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet("new")]
        public IActionResult New(NewWorkspaceModel workspace)
        {
            if (isLoggedIn)
            {
                return View("New", workspace);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost("create")]
        public IActionResult Create([FromForm] NewWorkspaceModel model)
        {
            model.UserId = (int)HttpContext.Session.GetInt32("UserId");
            var work = _mapper.Map<Workspace>(model);
            try
            {
                // create workspace
                _workspaceService.Create(work);
                return RedirectToAction("Dashboard", "Home", model.UserId);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var workspaces = _workspaceService.GetAll();
            var model = _mapper.Map<IList<WorkspaceModel>>(workspaces);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Info(int id)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            var thisWorkspace = _workspaceService.GetById(id);
            var model = _mapper.Map<WorkspaceModel>(thisWorkspace);
            var getUsers = _userService.GetAll();
            var AllUsers = _mapper.Map<IList<UserModel>>(getUsers);
            ViewBag.AllUsers = AllUsers;
            HttpContext.Session.SetInt32("WorkspaceId", id);
            return View("Info", model);
        }
        [HttpGet("{id}/update")]
        // [("{id}/update"), HttpPut]
        public IActionResult Update(WorkspaceModel model, int id, int userid)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            model.WorkspaceId = id;
            var workspace = _mapper.Map<Workspace>(model);
            _workspaceService.Update(workspace);
            return RedirectToAction("Info", "Workspace", new { id = id });
        }
        [HttpGet("{id}/delete")]
        public IActionResult Delete(int id, int userid)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            _workspaceService.Delete(id);
            return RedirectToAction("Dashboard", "Home", userid);
        }
    }
}
