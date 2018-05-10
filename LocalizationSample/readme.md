Мета проекту:
* додати локалізацію на View
* додати локалізацію на DataAnnotations
* встановити доступний перелік локалізацій
* встановлювати локалізацію з Request Header
* встановити локалізацію по-замовчуванню
* додати можливість зміни локалізації


Change log

First: localization resources
1. Create new asp net core MVC project
2. Add RequestModel.cs
3. Add RequestController - all localizations will be around this controller
4. Add resources for RequestController, Views and Models, see folder Resources
5. Change _ViewStart.cshtml - use localizer everywhere
6. Change Startup to use localization
see more info here https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-2.1

second step: add middleware to use culture in url, like http://loclahost/en-us/
1. Add Filters*
2. Change Startup, marked comments //localization middleware
3. Add attribute routing for every controller
4. Add swith language buttons to the footer

caveats:
resx - not good when you work with VS Code or use VS Studio on linux/mac os
I have to use attribute routing because of the following exception:
AmbiguousActionException: Multiple actions matched. 

thanks to this post https://andrewlock.net/using-a-culture-constraint-and-catching-404s-with-the-url-culture-provider/

thid step:
1. store localization text into database: https://github.com/damienbod/AspNetCoreLocalization
2. store localization text into JSON
