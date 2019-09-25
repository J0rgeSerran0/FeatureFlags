using DotNetCore.FeatureFlags;
using System;

namespace ConsoleToggleApp
{
    public class ToggleDemo
    {
        private readonly IToggle _toggle;

        public ToggleDemo(IToggle toggle)
        {
            _toggle = toggle;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FeatureFlags Loaded!");
            Console.WriteLine();

            Console.WriteLine($"Toggles Configurated: {_toggle.Count}");
            // Show the Toggles loaded
            ShowTogglesLoaded();

            // Check some Toggles to look for if they are enabled or not
            CheckTogglesStatuses();

            // Check if a Toggle exists or not
            CheckIfToggleIsEnabled("Foo");

            // Check if a Toggle exists or not
            CheckIfToggleExists("NotExists");

            // Released the Toggles
            ReleaseToggles();

            // Check some Toggles to look for if they are enabled or not
            CheckTogglesStatuses();

            // Refresh the Toggles
            RefreshToggles();
            
            // Check some Toggles to look for if they are enabled or not
            CheckTogglesStatuses();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private void ShowTogglesLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var toggleSettings = _toggle.GetAllToggleSettings();
            foreach (var settings in toggleSettings)
            {
                Console.WriteLine($"\t{settings.Feature} - {settings.Description} - {settings.IsEnabled}");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private void CheckTogglesStatuses()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Checking Toggles Statuses");
            Console.ForegroundColor = ConsoleColor.Cyan;

            var isEnabled = false;

            isEnabled = _toggle.IsEnabled("OtherFoo");
            Console.WriteLine($"\tOtherFoo is {isEnabled}");

            isEnabled = _toggle.IsEnabled("Foo");
            Console.WriteLine($"\tFoo is {isEnabled}");

            isEnabled = _toggle.IsEnabled("NotExists");
            Console.WriteLine($"\tNotExists is {isEnabled}");

            isEnabled = _toggle.IsEnabled(String.Empty);
            Console.WriteLine($"\tStringEmpty is {isEnabled}");

            Console.WriteLine();
        }

        private void CheckIfToggleIsEnabled(string feature)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Is Enabled the Toggle '{feature}'? {_toggle.IsEnabled(feature)}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
        }

        private void CheckIfToggleExists(string feature)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Exists the Toggle '{feature}'? {_toggle.ExistsToggle(feature)}");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private void ReleaseToggles()
        {
            _toggle.ReleaseToggles();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FeatureFlags Released!");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        private void RefreshToggles()
        {
            _toggle.ReloadToggles();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FeatureFlags Reloaded!");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}