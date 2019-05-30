using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.FeatureFlags
{
    public class Toggle : IToggle
    {
        private readonly IToggleService _toggleService;

        public Toggle(IToggleService toggleService)
        {
            _toggleService = toggleService;
        }

        public ToggleSettings GetToggleSettingsBy(string feature)
        {
            return _toggleService.GetToggleSettingsBy(feature);
        }

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

        public IList<ToggleSettings> GetAllToggleSettings()
        {
            return _toggleService.GetAllToggleSettings().ToList();
        }
    }
}