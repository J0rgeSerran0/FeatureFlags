# **DotNetCore.FeatureFlags**


# Introduction
Quick and easy implementation of *FeatureToggles* (**FeatureFlags**) in .NET Framework 4.6.1 or higher, .Net Core 3.0, ASP.NET Core 3.0 or Azure projects.

In the code you will see a sample to implement *FeatureFlags* on your .NET Core 3.x applications.

This implementation is quick easy, and you will have to implement the **IToggleService** only to manage the *Toggles*. 

# Release History

[Access to the Release History](ReleaseHistory.md)

# How-To
In the next image you will see the projet's class diagram.
![screenshot](https://raw.githubusercontent.com/J0rgeSerran0/FeatureFlags/master/images/class_diagram.png) 

You should know that:
- The class **ToggleSettings** has the properties of the *Toggle* (Feature, Description, IsEnabled)
    - *Feature* is the name or key of the *Toggle*
    - *Description* is the description of the *Toggle* (empty by default)
    - *IsEnabled* is the value of the *Toggle* (on/off) where off is the default value

You will have to take two actions on your code only:
- Implement the **IToggleService** interface to manage the *Toggles* (load, get, release and reload the *Toggles*) from the source where you have them.
- Use the **Toggle** class on your app to manage the *Toggles* and know if a *Toggle* is enabled or not.

Implement the library is quick and easy as you can see.

# Usage
This is a general use of this library.

## Implementation of IToggleService
First, you have to implement the IToggleService interface:

```csharp
public class MyService : IDisposable, IToggleService
{
    private IList<ToggleSettings> _toggleSettings = new List<ToggleSettings>();

    public int Count { get { return _toggleSettings.Count; } }

    public MyService() => ReloadToggles();

    public void Dispose()
    {
        _toggleSettings = null;
    }

    public bool ExistsToggle(string feature) => GetToggleSettingsBy(feature) != null;

    public IList<ToggleSettings> GetAllToggleSettings() => _toggleSettings;

    public ToggleSettings GetToggleSettingsBy(string feature) => _toggleSettings.Where(q => q.Feature == feature).SingleOrDefault();

    public void ReloadToggles()
    {
        var toggleSettings = new List<ToggleSettings>();
        toggleSettings.Add(new ToggleSettings("MyFeature", "My toggle code", false));

        _toggleSettings = toggleSettings;
    }

    public void ReleaseToggles()
    {
        _toggleSettings = new List<ToggleSettings>();
    }
}
```

## Configure the Service
Second, you have to configure the service that we have implemented to be used by our application code:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    AddServices(services);
}

...

private void AddServices(IServiceCollection services)
{
    services.AddSingleton<IToggle, Toggle>()
        .AddSingleton<IToggleService, MyService>()
        .BuildServiceProvider();
}
```

## Use the library on your code
Finally, we will be ready to use the library on our code:

```csharp
private readonly IToggle _toggle;

public MyClass(IToggle toggle)
{
    _toggle = toggle;
}

public void MyMethod()
{
    var feature = "MyFeature";
    
    if (_toggle.ExistsToggle(feature) && 
        _toggle.GetToggleSettingsBy(feature).IsEnabled)
    {
        MyMethodWithFeatureToggle();
    }
    else
    {
        MyCurrentMethod();
    }
}

private void MyMethodWithFeatureToggle()
{
    // Here the code of the new method
    // testable through Feature Toggles
}

private void MyCurrentMethod()
{
    // Here the actual code 
}

```

- Note: to give more flexibility, you could use the service to manage your toggles too, however I recommend you to use the IToggle interface.

# Samples (source code)
There are some samples using this NuGet Package.
- A console application
- An ASP.NET 3.0 MVC Web App

You will find the  samples [here](https://github.com/J0rgeSerran0/FeatureFlags/tree/master/src/Sample)

# NuGet Package
You can install the [Nuget Package of *DotNEtCore.FeatureFlags* from here](https://www.nuget.org/packages/DotNetCore.FeatureFlags/)

# References
[FeatureToggle of Martin Fowler](https://martinfowler.com/bliki/FeatureToggle.html)

[Explore how to progressively expose your features in production for some or all users](https://docs.microsoft.com/en-us/azure/devops/migrate/phase-features-with-feature-flags?view=azure-devops)

[FeatureFlags - additional information](https://featureflags.io/)
