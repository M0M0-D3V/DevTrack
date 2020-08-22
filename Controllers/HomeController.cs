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
using DevTrack.Models;

namespace DevTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            if (isLoggedIn)
            {
                return RedirectToAction("Dashboard", new { userId = (int)uid });
            }
            return View("Index");
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard(UserModel userId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Dashboard", userId);
        }
        public IActionResult Privacy()
        {
            return View();
        }
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
