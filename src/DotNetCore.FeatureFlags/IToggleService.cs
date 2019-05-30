using System.Collections.Generic;

namespace DotNetCore.FeatureFlags
{
    public interface IToggleService
    {
        IList<ToggleSettings> GetAllToggleSettings();
        ToggleSettings GetToggleSettingsBy(string feature);
        void RefreshToggles();
        void ReleaseToggles();
    }
}