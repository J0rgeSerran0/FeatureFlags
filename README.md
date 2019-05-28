# Introduction
Quick and easy implementation of *FeatureFlags* in .Net Core applications

In the code you will see a sample to implement *FeatureFlags* on your .NET Core 3.x applications.

This implementation is quick easy, and you will have to implement the **IToggleService** only to manage the *Toggles*. 

# How-To
In the next image you will see the projet's class diagram.
![screenshot](https://raw.githubusercontent.com/J0rgeSerran0/FeatureFlags/master/images/class_diagram.png) 

You should know that:
- The class **ToggleSettings** has the properties of the *Toggle* (Feature, Description, IsEnabled)
    - *Feature* is the name or key of the *Toggle*
    - *Description* is the description of the *Toggle* (empty by default)
    - *IsEnabled* is the value of the *Toggle* (on/off) where off is the default value

You will have to take two actions on your code only:
- Implement the **IToggleService** interface to manage the *Toggles* (load, get, release and refresh the *Toggles*) from the source where you have them.
- Use the **Toggle** class on your app to manage the *Toggles* and know if a *Toggle* is enabled or not.

Implement the library is quick and easy as you can see.

# References
[FeatureToggle of Martin Fowler](https://martinfowler.com/bliki/FeatureToggle.html)

[Explore how to progressively expose your features in production for some or all users](https://docs.microsoft.com/en-us/azure/devops/migrate/phase-features-with-feature-flags?view=azure-devops)

[FeatureFlags - additional information](https://featureflags.io/)
