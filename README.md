# Solution AspNetCore21WebApp
An ASP.NET Core 2.1 Web Application to test developing using Code First, migrations, different types of relationships, and Github from Visual Studio 2017. (P.S. Dates are in Swedish format, i.e. YYYY-MM-DD.)

## Security warning

*Please* update any dependencies before using code in this repository! (I've already had one security warning regarding jQuery library.)

## Background
I'm currently developing a simple application, similar to this one, and need a project to test things I haven't done yet, like adding a mandatory field, which should require creating column in database with a default value. ;-)

The solution was created in Visual Studio 2017 using ASP.NET Core version 2.1 (i.e. a bit "outdated") using SQL Server Express LocalDB.

The project is developed for the fictitious company "Kilted Viking's Cruises" (in an attempt to make it a bit more fun ;-)). References to more information are inserted as comments in code and any customisations of "standard code" are tagged by comments starting with BP.

## Model
The basic idea is to manage cruise ships.
* Ship - the cruise ship, which contains or transports the other entities.
* Restaurant - a restaurant on a ship.
* Menu - a menu for a restaurant. When adding a new menu (for a restaurant) and approving it, it will replace the previous menu.
* Cruise - a period during which customers can book.
* Passenger - person having booked a cruise.
* Cabin - cabin that can be booked.
* Activity - an activity on board that can be booked by passenger (customer).

### Parts implemented so far
So far, I've only got as far as creating the entities Ship, Restaurant, and Menu. (I'm still working on the concept "current menu" and how to handle multiple menus. ;-))

### TODO 2020-03-28
The plan is to add a mandatory field Year (or YearValid) to Menu using Migration, which should require me to add some code to method OnModelCreating that sets the newly added field as mandatory and a default value.

## Things learnt

This section contains some things learnt while working with this project. One thing learnt is the nice Github function that checks for vunerabilities in code, like jQuery libraries.

### Updating client-side libraries

I got a warning from Github about vunerability about version of jQuery (v. 3.3.1), so I decided to update the package (and Bootstrap) only to find out that it couldn't be done via NuGet package manager... :-( Luckily I found Steve Gordon's blog post below, which showed me how to use Visual Studio's Library Manager to upgrade packages. ;-)

https://www.stevejgordon.co.uk/library-manager-libman-visual-studio-2017

So I followed steps to add LibMan's manifest file (`libman.json`) to project, copied the content of property `libraries` and made changes to update my libraries. (Please note that I didn't move to Bootstrap v. 4. ;-)) I also added settings for upgrading jQuery-validation libraries, which auto-complete made easy.

```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": [
    {
      "library": "twitter-bootstrap@3.4.1",
      "destination": "wwwroot/lib/bootstrap",
      "files": [
        "js/bootstrap.min.js",
        "css/bootstrap-theme.min.css",
        "css/bootstrap.min.css",
        "fonts/glyphicons-halflings-regular.eot",
        "fonts/glyphicons-halflings-regular.svg",
        "fonts/glyphicons-halflings-regular.ttf",
        "fonts/glyphicons-halflings-regular.woff",
        "fonts/glyphicons-halflings-regular.woff2"
      ]
    },
    {
      "library": "jquery@3.5.0",
      "destination": "wwwroot/lib/jquery",
      "files": [
        "jquery.min.js"
      ]
    },
    {
      "library": "jquery@3.5.0",
      "destination": "wwwroot/lib/jquery",
      "files": [
        "jquery.min.js"
      ]
    },
    {
      "library": "jquery-validate@1.19.1",
      "destination": "wwwroot/lib/jquery-validation/",
      "files": [
        "jquery.validate.min.js"
      ]
    },
    {
      "library": "jquery-validation-unobtrusive@3.2.11",
      "destination": "wwwroot/lib/jquery-validation-unobtrusive/",
      "files": [
        "jquery.validate.unobtrusive.min.js" 
      ]
    }
  ]
}
```

## Thanks

Thanks to Steve Gordon and all others sharing their knowledge helping me to move forward in developing! ;-)


Björn G. D. Persson
"KIlted Viking"
2020-03-28
