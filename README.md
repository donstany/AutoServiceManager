# INTERVIEW TASK

Recommended but not mandatory
------------------------------------------------------------------------------------
[Back End - ASP.NET Web API] ⇔ [Middleware - jQuery] ⇔ [Front End - jQuery + HTML]
------------------------------------------------------------------------------------

I. Objects:
	
	1. Users
		a. Names *
		b. Email *
		c. Password *
		d. Role * - Manager or Mechanic
	2. Orders
		a. Number - automatically generated, without editing option
		b. Date and time - automatically generated, with an option to edit
		c. Car * - select from a list
	d. Description of the problem * - from 5 to 300 characters
		3. Cars
		a. Brand *
		b. Color *
		c. Registration number

II. Pages
	
	1. Login
		a. Email and Password
	2. Users
		a. Add/Edit/Delete
		b. Only Managers have access
	3. Orders
		a. Add/Edit/Delete
		b. When adding or editing, to be able to add or select an already existing one car. 
		The addition is with its respective parameters.
	4. Report
		a. A single text field to search among the parameters of each query and the cars to her.
		b. The results should contain "Request No", "Date and Time", "Vehicle Data", "User data
	(no password)", "Description of the problem"

Clarifications
--------------

Managers:

(Default to have manager with static login)

	a. Users - Access Allowed
	b. Orders - Access allowed, See all report
	c. Report - Access Allowed

Mechanics:

	a. Users - Access Denied
	b. Orders - Access allowed, Only see their report
	c. Report - Access Allowed


Estimation
----------

Demonstrate implementations, good practices, (architecture/design) patterns and writing coding style.


SOLUTION 
========


# Clean Architecture Boilerplate - ASP.NET Core 5.0 (WebApi & MVC)

Built with Domain Driven Design/Onion/Hexagonal Architecture

Clean Architecture Solution Template for ASP.NET Core 5.0. 

used template from https://aspnetboilerplate.com/

## Technologies Used

- ASP.NET Core 5.0 WebAPI
- ASP.NET Core 5.0 MVC
- Entity Framework Core 5.0

## Features Included

### ASP.NET Core 5.0 MVC Project
- Slim Controllers using MediatR Library
- Permissions Management based on Role Claims
- Toast Notification (includes support for AJAX Calls too)
- Serilog
- ASP.NET Core Identity
- AdminLTE Bootstrap Template (Clean & SuperFast UI/UX)
- AJAX for CRUD (Blazing Fast load times)
- jQuery Datatables
- Select2
- Image Optimization
- Includes Sample CRUD Controllers / Views
- Active Route Tag Helper for UI
- RTL Support
- Complete Localization Support / Multilingual
- Clean Areas Implementation
- Dark Mode!
- Default Users / Roles Seeding at Startup
- Supports Audit Logging / Activity Logging for Entity Framework Core
- Automapper