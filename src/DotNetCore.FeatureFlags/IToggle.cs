namespace DotNetCore.FeatureFlags
{
    public interface IToggle : IToggleService
    {
        bool IsEnabled(string feature);
    }
}