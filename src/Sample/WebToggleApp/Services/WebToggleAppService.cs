using DotNetCore.FeatureFlags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebToggleApp.Services
{
    public class WebToggleAppService : IDisposable, IToggleService
    {
        private IList<ToggleSettings> _toggleSettings = new List<ToggleSettings>();

        public int Count { get { return _toggleSettings.Count; } }

        public WebToggleAppService() => ReloadToggles();

        public void Dispose()
        {
            _toggleSettings = null;
        }

        public bool ExistsToggle(string feature) => GetToggleSettingsBy(feature) != null;

        public IList<ToggleSettings> GetAllToggleSettings() => _toggleSettings;

        public ToggleSettings GetToggleSettingsBy(string feature) => _toggleSettings.Where(q => q.Feature == feature).SingleOrDefault();

        public void ReloadToggles()
        {
            var toggleSettings = new List<ToggleSettings>();
            toggleSettings.Add(new ToggleSettings("IndexNewFeature", "New feature in the home/index page", false));
            toggleSettings.Add(new ToggleSettings("MyOtherFeature", "Other foo feature", false));

            _toggleSettings = toggleSettings;
        }

        public void ReleaseToggles()
        {
            _toggleSettings = new List<ToggleSettings>();
        }
    }
}
