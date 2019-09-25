using DotNetCore.FeatureFlags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using WebToggleApp.Models;

namespace WebToggleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToggleService _toggleService;

        public HomeController(ILogger<HomeController> logger, IToggleService toggleService)
        {
            _logger = logger;
            _toggleService = toggleService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var feature = "IndexNewFeature";
            var isEnabled = false;

            if (_toggleService.ExistsToggle(feature))
            {
                isEnabled = _toggleService.GetToggleSettingsBy(feature).IsEnabled;
            }

            return View(isEnabled);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ReloadToggles()
        {
            _toggleService.ReloadToggles();

            return RedirectToAction("Index");
        }

        public IActionResult ReleaseToggles()
        {
            _toggleService.ReleaseToggles();

            return RedirectToAction("Index");
        }

        public IActionResult Settings()
        {
            var myToggles = new List<ToggleModel>();

            var toggles = _toggleService.GetAllToggleSettings();

            foreach (var toggle in toggles)
            {
                var toggleModel = new ToggleModel(toggle.Feature, toggle.Description, toggle.IsEnabled);
                myToggles.Add(toggleModel);
            }

            return View(myToggles);
        }

        public IActionResult ToggleToOn(string feature)
        {
            if (_toggleService.ExistsToggle(feature))
            {
                var toggle = _toggleService.GetToggleSettingsBy(feature);
                toggle.IsEnabled = true;
            }

            return RedirectToAction("Index");
        }

        public IActionResult ToggleToOff(string feature)
        {
            if (_toggleService.ExistsToggle(feature))
            {
                var toggle = _toggleService.GetToggleSettingsBy(feature);
                toggle.IsEnabled = false;
            }

            return RedirectToAction("Index");
        }
    }
}