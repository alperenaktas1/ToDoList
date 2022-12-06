using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IMissionService _missionManager;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IMissionService missionManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _missionManager = missionManager;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _missionManager.GetAllByUser(user.Id);
            return View(values);
        }

        public IActionResult DeleteMission(int id)
        {
            var deleteValue = _missionManager.GetById(id);
            _missionManager.Delete(deleteValue);
            return RedirectToAction("Index");
        }

        public IActionResult ComplatedMission(int id)
        {
            var result = _missionManager.GetById(id);
            if (result.MissionState == false)
            {
                result.MissionState = true;
            }
            else
            {
                result.MissionState = false;
            }
            _missionManager.Update(result);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddMission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMission(Mission mission)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            mission.UserId = user.Id;
            _missionManager.Add(mission);
            return RedirectToAction("Index");
        }

        public PartialViewResult AddPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult CreateMission()
        {

            return View();
        }

        [HttpPost]


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}