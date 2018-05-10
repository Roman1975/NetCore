# Мета проекту:
* додати локалізацію на View
* додати локалізацію на DataAnnotations
* встановити доступний перелік локалізацій
* встановлювати локалізацію з Request Header
* встановити локалізацію по-замовчуванню
* додати можливість зміни локалізації


# Change log

## First step: localization resources
* Create new asp net core MVC project
* Add RequestModel.cs
* Add RequestController - all localizations will be around this controller
* Add resources for RequestController, Views and Models, see folder Resources
* Change _ViewStart.cshtml - use localizer everywhere
* Change Startup to use localization
see more info here https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-2.1

### caveats:
resx - not good when you work with VS Code or use VS Studio on linux/mac os, also you have to rebuild yours projects every time. No need to change resx when you upgrade solution.

## Second step: add middleware to use culture in url, like http://loclahost/en-us/
thanks to this post https://andrewlock.net/using-a-culture-constraint-and-catching-404s-with-the-url-culture-provider/
* Add Filters*
* Change Startup, marked comments //localization middleware
* Add attribute routing for every controller
* Add swith language buttons to the footer

### caveats:
I have to use "attribute routing" because of the following exception:
AmbiguousActionException: Multiple actions matched. 
Have to spend more time to fix this situation.


## Thid step: store localization text into PO files
see more info about [PO files](https://www.gnu.org/savannah-checkouts/gnu/gettext/manual/html_node/PO-Files.html)

* copy project to new folder and rename it to LocalizationJson
* add nuget package My.Extensions.Localization.Json
* change startup.cs, Resources folder, views and controllers

### caveats:
There is some bugs with Data Annotation. 
The main idea how to override that kind of problems - use Localization on View only, see _Layout.cshtml or Create.cshtml

## Forth step: store localization text into database: https://github.com/damienbod/AspNetCoreLocalization
