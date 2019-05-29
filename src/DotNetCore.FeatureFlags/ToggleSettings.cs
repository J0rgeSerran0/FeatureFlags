namespace DotNetCore.FeatureFlags
{
    public class ToggleSettings
    {
        public string Feature { get; }
        public string Description { get; }
        public bool IsEnabled { get; }

        public ToggleSettings(string feature) : this(feature, string.Empty) { }

        public ToggleSettings(string feature, string description, bool isEnabled = false)
        {
            Feature = feature;
            Description = description;
            IsEnabled = isEnabled;
        }
    }
}