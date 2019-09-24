using DotNetCore.FeatureFlags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyToggles
{
    public class MyToggleService : IDisposable, IToggleService
    {
        private IList<ToggleSettings> _toggleSettings = new List<ToggleSettings>();

        public int Count { get { return _toggleSettings.Count; } }

        public MyToggleService()
        {
            RefreshToggles();
        }

        public void Dispose()
        {
            _toggleSettings = null;
        }

        public bool ExistsToggle(string feature) => GetToggleSettingsBy(feature) != null;

        public IList<ToggleSettings> GetAllToggleSettings() => _toggleSettings;

        public void RefreshToggles()
        {
            var toggleSettings = new List<ToggleSettings>();
            toggleSettings.Add(new ToggleSettings("Foo", "Toggle Foo", true));
            toggleSettings.Add(new ToggleSettings("OtherFoo", "Toggle Other Foo", false));

            _toggleSettings = toggleSettings;
        }

        public ToggleSettings GetToggleSettingsBy(string feature) => _toggleSettings.Where(q => q.Feature == feature).SingleOrDefault();

        public void ReleaseToggles()
        {
            _toggleSettings = new List<ToggleSettings>();
        }

    }
}