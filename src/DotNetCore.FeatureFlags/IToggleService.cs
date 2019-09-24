using System.Collections.Generic;

namespace DotNetCore.FeatureFlags
{
    public interface IToggleService
    {
        int Count { get; }
        bool ExistsToggle(string feature);
        IList<ToggleSettings> GetAllToggleSettings();
        ToggleSettings GetToggleSettingsBy(string feature);
        void RefreshToggles();
        void ReleaseToggles();
    }
}