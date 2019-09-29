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
        private readonly IToggle _toggle;

        public HomeController(ILogger<HomeController> logger, IToggle toggle)
        {
            _logger = logger;
            _toggle = toggle;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public IActionResult Index()
        {
            var feature = "IndexNewFeature";
            var isEnabled = false;
            
            if (_toggle.ExistsToggle(feature))
            {
                isEnabled = _toggle.GetToggleSettingsBy(feature).IsEnabled;
            }

            return View(isEnabled);
        }

        public IActionResult About() => View();

        public IActionResult ReloadToggles()
        {
            _toggle.ReloadToggles();

            return RedirectToAction("Index");
        }

        public IActionResult ReleaseToggles()
        {
            _toggle.ReleaseToggles();

            return RedirectToAction("Index");
        }

        public IActionResult Settings()
        {
            var myToggles = new List<ToggleModel>();

            var toggles = _toggle.GetAllToggleSettings();

            foreach (var toggle in toggles)
            {
                var toggleModel = new ToggleModel(toggle.Feature, toggle.Description, toggle.IsEnabled);
                myToggles.Add(toggleModel);
            }

            return View(myToggles);
        }

        public IActionResult ToggleToOn(string feature)
        {
            if (_toggle.ExistsToggle(feature))
            {
                var toggle = _toggle.GetToggleSettingsBy(feature);
                toggle.IsEnabled = true;
            }

            return RedirectToAction("Index");
        }

        public IActionResult ToggleToOff(string feature)
        {
            if (_toggle.ExistsToggle(feature))
            {
                var toggle = _toggle.GetToggleSettingsBy(feature);
                toggle.IsEnabled = false;
            }

            return RedirectToAction("Index");
        }
    }
}