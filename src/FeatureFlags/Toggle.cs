using System.Collections.Generic;
using System.Linq;

namespace FeatureFlags
{
    public class Toggle : IToggle
    {
        private readonly IToggleService _toggleService;

        public Toggle(IToggleService toggleService)
        {
            _toggleService = toggleService;
        }

        public IList<ToggleSettings> GetToggleSettings()
        {
            return _toggleService.GetToggleSettings();
        }

        public bool IsEnabled(string feature)
        {
            return GetToggleSettings(feature).IsEnabled;
        }

        public void RefreshToggles()
        {
            _toggleService.RefreshToggles();
        }

        public void ReleaseToggles()
        {
            _toggleService.ReleaseToggles();
        }

        private ToggleSettings GetToggleSettings(string feature)
        {
            var toggleSettings = _toggleService.GetToggleSettings().Where(q => q.Feature == feature).SingleOrDefault();
            return toggleSettings ?? new ToggleSettings(feature);
        }
    }
}