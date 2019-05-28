using FeatureFlags;
using System;

namespace ConsoleToggleApp
{
    public class ToggleDemo
    {
        public ToggleDemo(IToggle toggle)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FeatureFlags Loaded!");

            // Show the Toggles loaded
            Console.ForegroundColor = ConsoleColor.Green;
            var toggleSettings = toggle.GetToggleSettings();
            foreach (var settings in toggleSettings)
            {
                Console.WriteLine($"{settings.Feature} - {settings.Description} - {settings.IsEnabled}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Check some Toggles to look for if they are enabled or not
            var isEnabled = false;

            isEnabled = toggle.IsEnabled("OtherFoo");
            Console.WriteLine($"OtherFoo is {isEnabled}");

            isEnabled = toggle.IsEnabled("Foo");
            Console.WriteLine($"Foo is {isEnabled}");

            isEnabled = toggle.IsEnabled("NotExists");
            Console.WriteLine($"NotExists is {isEnabled}");

            isEnabled = toggle.IsEnabled(String.Empty);
            Console.WriteLine($"StringEmpty is {isEnabled}");

            // Released the Toggles
            toggle.ReleaseToggles();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("FeatureFlags Released!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            isEnabled = toggle.IsEnabled("Foo");
            Console.WriteLine($"Foo is {isEnabled}");
            Console.WriteLine();

            // Refresh the Toggles
            toggle.RefreshToggles();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("FeatureFlags Reloaded!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            isEnabled = toggle.IsEnabled("Foo");
            Console.WriteLine($"Foo is {isEnabled}");
            Console.WriteLine();



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
