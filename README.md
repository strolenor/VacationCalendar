# VacationCalendar
.Net Core 3.1 app


To setup the app first either mount provided database Vacation1.bak
or run update-database scripts for both DbContext's

No special configuration is needed to run the app

When running the app, first you will be redirected to the Index action of the Calendar controller
Calendar will be displayed with following functionalities:
All currently employed Employees will have their Schedules displayed
There are multiple different types of day:
Workday,
Weekend
Sick leave,
Vacation leave,
Holiday

Every day type has its own background color

Sick leave, Vacation leave and Holiday are not displayed as status during weekends
By default Saturday and Sunday are taken as Weekend days

If employee has a sick leave during holiday, holiday is displayed
It is possible to click on any day to edit it for any user
If user clicks on other users calendar entry, user can edit it only if it has a Admin role, else Exception will be thrown
Delete entry is not yet implemented
Success/Failure message after editing calendar entry is not yet implemented

It is possible to navigate to next and previous month by using arrows above the table

It is possible to register, login and logout user, by default
By default User role is added to every user, and during registration it is possible to chose if user is an Admin or not
No user Role management is yet implemented

Solution has 151MB because no git.ignore file has been added and because database has been attached to it