# Solution AspNetCore21WebApp
An ASP.NET Core 2.1 Web Application to test developing using Code First and Migrations. (P.S. Dates are in Swedish format, i.e. YYYY-MM-DD.)

## Background
I'm currently developing a simple application, similar to this one, and need a project to test things I haven't done yet, like adding a mandatory field, which should require creating column in database with a default value. ;-)

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

Björn G. D. Persson
"KIlted Viking"
2020-03-28
