using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.FeatureFlags
{
    public class Toggle : IToggle
    {
        private readonly IToggleService _toggleService;

        public int Count { get { return _toggleService.Count; } }

        public Toggle(IToggleService toggleService)
        {
            _toggleService = toggleService;
        }

        public bool ExistsToggle(string feature) => _toggleService.ExistsToggle(feature);

        public IList<ToggleSettings> GetAllToggleSettings() => _toggleService.GetAllToggleSettings().ToList();

        public ToggleSettings GetToggleSettingsBy(string feature) => _toggleService.GetToggleSettingsBy(feature);

        public bool IsEnabled(string feature)
        {
            var toggleSettings = GetToggleSettingsBy(feature);
            return toggleSettings == null ? false : toggleSettings.IsEnabled;
        }

        public void RefreshToggles()
        {
            _toggleService.RefreshToggles();
        }

        public void ReleaseToggles()
        {
            _toggleService.ReleaseToggles();
        }

    }
}