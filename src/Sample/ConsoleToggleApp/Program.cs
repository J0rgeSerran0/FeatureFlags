using DotNetCore.FeatureFlags;
using Microsoft.Extensions.DependencyInjection;
using MyToggles;

namespace ConsoleToggleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IToggle, Toggle>()
                .AddSingleton<IToggleService, MyToggleService>()
                .BuildServiceProvider();

            var toggleDemo = new ToggleDemo(serviceProvider.GetService<IToggle>());
        }
    }
}