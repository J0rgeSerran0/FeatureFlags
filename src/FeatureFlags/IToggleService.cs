using System.Collections.Generic;

namespace FeatureFlags
{
    public interface IToggleService
    {
        IList<ToggleSettings> GetToggleSettings();
        void RefreshToggles();
        void ReleaseToggles();
    }
}