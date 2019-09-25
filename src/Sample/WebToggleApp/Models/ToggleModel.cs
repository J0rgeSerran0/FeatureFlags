namespace WebToggleApp.Models
{
    public class ToggleModel
    {
        public string Feature { get; private set; }
        public string Description { get; private set; }
        public bool IsEnabled { get; private set; }

        public ToggleModel(string feature, string description, bool isEnabled)
        {
            Feature = feature;
            Description = description;
            IsEnabled = isEnabled;
        }
    }
}