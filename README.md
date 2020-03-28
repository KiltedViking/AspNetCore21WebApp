# Solution AspNetCore21WebApp
An ASP.NET Core 2.1 Web Application to test developing using Code First and Migrations. (P.S. Dates are in Swedish format, i.e. YYYY-MM-DD.)

## Background
I'm currently developing a simple application, similar to this one, and need a project to test things I haven't done yet, like adding a mandatory field, which requires setting a default value. ;-)

## Model
The basic idea is to manage cruise ships.

### Parts implemented so far
So far, I've only got as far as creating the entities Ship, Restaurant, and Menu.

### TODO 2020-03-28
The plan is to add a mandatory field Year (or YearValid) to Menu using Migration, which should require me to add some code to method OnModelCreating that sets the newly added field as mandatory and a default value.

Björn G. D. Persson
"KIlted Viking"
2020-03-28
