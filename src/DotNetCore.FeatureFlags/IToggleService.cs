using System.Collections.Generic;

namespace DotNetCore.FeatureFlags
{
    public interface IToggleService
    {
        IList<ToggleSettings> GetToggleSettings();
        void RefreshToggles();
        void ReleaseToggles();
    }
}