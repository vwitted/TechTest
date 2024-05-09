# User Management Technical Exercise

The exercise is an ASP.NET Core web application backed by Entity Framework Core, which faciliates management of some fictional users.
We recommend that you use [Visual Studio (Community Edition)](https://visualstudio.microsoft.com/downloads) or [Visual Studio Code](https://code.visualstudio.com/Download) to run and modify the application. 


# Packages

 - There are additional packages installed via NuGet:
 In UserManagement.Data, the following dependencies have been added, as part of migrating the system to a SQL Database. 
"Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7.0.18"
"Microsoft.EntityFrameworkCore" Version="7.0.18" 
"Microsoft.EntityFrameworkCore.Abstractions" Version="7.0.18"
"Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.18"
"Microsoft.EntityFrameworkCore.Tools" Version="7.0.18"
"Microsoft.Extensions.DependencyInjection.Abstractions" Version="7.0.0"

In UserManagement.Web:
"X.PagedList.Mvc.Core" Version="9.1.2"

# Database Changes
As Part of the changes I've made to the system, I have migrated Entity Framework over to a Sql Database in order to add
long-term persistence to the data. The Connection String may will need to be configured to a database locally and EF used to migrate initially. 


### 1. Filters Section (Standard)

The users page contains 3 buttons below the user listing - **Show All**, **Active Only** and **Non Active**. Show All has already been implemented. Implement the remaining buttons using the following logic:
* Active Only – This should show only users where their `IsActive` property is set to `true`
* Non Active – This should show only users where their `IsActive` property is set to `false`

### 2. User Model Properties (Standard)

Add a new property to the `User` class in the system called `DateOfBirth` which is to be used and displayed in relevant sections of the app.

### 3. Actions Section (Standard)

Create the code and UI flows for the following actions
* **Add** – A screen that allows you to create a new user and return to the list
* **View** - A screen that displays the information about a user
* **Edit** – A screen that allows you to edit a selected user from the list  
* **Delete** – A screen that allows you to delete a selected user from the list

Each of these screens should contain appropriate data validation, which is communicated to the end user.

### 4. Data Logging (Advanced)

Extend the system to capture log information regarding primary actions performed on each user in the app.
* In the **View** screen there should be a list of all actions that have been performed against that user. 
* There should be a new **Logs** page, containing a list of log entries across the application.
* In the Logs page, the user should be able to click into each entry to see more detail about it.
* In the Logs page, think about how you can provide a good user experience - even when there are many log entries.

### 5. Extend the Application (Expert)


* Update the data access layer to use a real database, and implement database schema migrations.

## Additional Notes

* Please feel free to change or refactor any code that has been supplied within the solution and think about clean maintainable code and architecture when extending the project.
* If any additional packages, tools or setup are required to run your completed version, please document these thoroughly.
