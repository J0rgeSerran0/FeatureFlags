using FeatureFlags;
using System;
using System.Collections.Generic;

namespace MyToggles
{
    public class MyToggleService : IDisposable, IToggleService
    {
        private IList<ToggleSettings> _toggleSettings = new List<ToggleSettings>();

        public MyToggleService()
        {
            RefreshToggles();
        }

        public void Dispose()
        {
            _toggleSettings = null;
        }

        public IList<ToggleSettings> GetToggleSettings()
        {
            return _toggleSettings;
        }

        public void RefreshToggles()
        {
            var toggleSettings = new List<ToggleSettings>();
            toggleSettings.Add(new ToggleSettings("Foo", "Toggle Foo", true));
            toggleSettings.Add(new ToggleSettings("OtherFoo", "Toggle Other Foo", false));

            _toggleSettings = toggleSettings;
        }

        public void ReleaseToggles()
        {
            _toggleSettings = new List<ToggleSettings>();
        }
    }
}