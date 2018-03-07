# Employee Premium Back-end
This is a Backend service project for a Coding challenge. This application utilized ASP.NET Core 2.0 built in C#.

## Basic design consideration building the components

-Compatibility 
-Extensibility 
-Maintainability
-Modularity 
-Reliability 
-Usability 

Based on the above features we can easily scale-up this application to utilize for large-scale.

## Componenets of the app
-API
Api is an interface for building HTTP Web Services that can be used to retrieve, create or update data. Basically this is presentation layer of the our project that communicate to outer world.

-DTO
This is the core of our application. To determine what we are going to implement in this project. I utilize TypeWriter to generate the Typescript definitions automatically.
 
-Data
The Data Layer is built in C#, with Entity Framework Core.
It also have a repository that communicate with the Database.

-FNS
This is basically library that contain the Buisness logic. Having buisness logic in c# layer have many advantages. Some of them are;

1)Maintability
Easily configured and testable.

2)Extensibility
Having business logic (BL) here will also pot less effect on Database side. If we want to change the DB we can easily change it without effecting any kind of BL. Also storing data after applying BL is overhead for the DB (again what we can do if business change his logic??). 

3)Usability 
This can also giving advantage on Front end side. Let suppose we create an app in Angular today. Tommorow we are going to used React so we dont worry about all the complex calculation that need to transfer.

-Entities
Used this to generate a EF entities.

-Test
To test our project. I also utilized Postman to test the API's.
 

## Employee Premium Front-End

The frontend is generated with Angular CLI. Angular CLI is a preferred way to get started with an Angular project. It not only saves time, but also makes it easy to maintain the code base during the course of the project, with features to add additional components, services etc. 
    
TypeScript,
which primarily provides optional static typing, classes and interfaces. One of the big benefits is to enable IDEs to provide a richer environment for spotting common errors as you type the code.

Bootstrap: layout and styles. 


Angular, A component-based architecture that provides a higher quality of code.

-->(https://blog.codewithdan.com/2017/08/26/5-key-benefits-of-angular-and-typescript/)

## For Future
--Implement security in BE as well as in FE project so only authorized user exchange information.
--Edit and Delete functionality
--Make async calls.
--Utilize Lazy loading in FE side
--Used Reduer to state management as the router navigation invokes the reducer, and then once the reducer is done, the navigation proceeds using the new state.
--Styling


## Installation Instructions

1. Install the latest [.NET Core](https://www.microsoft.com/net/learn/get-started).
2. Install the latest [nodeJS](https://nodejs.org).
3. Install Angular CLI 
npm i --save-dev --save-exact @angular/cli@latest.
4. Make sure you have an instance of SQL Server, SQL Server Express, or localdb available to the machine that will run this code.
5. By default, hrdemo assumes that there is a SQL Server instance located at "`(localdb)\\projectsv13`".  If you would like to change this, either set an variable in API Project (appSetting.json)

 "EmployeeDBConnectionString": "Server=(localdb)\\projectsv13;Database=EmployeeDB;Integrated Security=true;MultipleActiveResultSets=true;"
    ```
6. After setting your connection string, make sure you're in the `data` directory, then set up the database using Entity Framework Core with the command: 
    ```
    dotnet ef database update

Testing
Run the test created in Test library to check if its connected to DB.

OR
     
1. Navigate to the `api` directory then run the command `dotnet run` .  Feel free to hit `http://localhost:8080/api/EmployeeDetails` from your browser to test out the API.

FE Project

1. Open a new command prompt.  Navigate to repo's. (https://github.com/syedabdi/CodingChallenge-FE)

2.Get the app and goto the root folder of the app.
3. Run the command `npm i && npm run start` to install all NPM dependencies then ng serve -o to run the application.  It should open the front-end on `http://localhost:4200` and automatically communicate with the back-end using CORS.
