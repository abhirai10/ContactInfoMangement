PROJECT OVERVIEW
In this Project I have created a Web API application and implemented GET, POST, PUT and DELETE method for CRUD operation using Entity Framework DB-First approach to access an existing contactDb database. 
After creating the Web API that handles HTTP GET, POST, PUT and DELETE requests respectively. I have also consumed Web API in ASP.NET MVC using HttpClient in the MVC controller. So that CRUD operations can be performed with UI.
The dependency injector used to resolve the dependency is Ninject.

Steps to run the application
1)	Download the repository from the GIT repository
2)	Restore database ContactDb.bak in SQL server Management Studio
3)	Run the ContactInfoManagement.sln 
4)	Press Ctrl+ F5 to run the application.
5)	To run all the Unit Test cases click on TEST -> Run -> All Tests.

Use Fiddler with the specified Response Header and URI to perform below functionalities

1)	List all contacts(GET)- http://localhost:51850/api/contacts
2)	List Specific record(GET)- http://localhost:51850/api/contacts/1
3)	Add a contact (POST) - http://localhost:51850/api/contacts 
4)	Edit contact (PUT) - http://localhost:51850/api/contacts/10
5)	Delete contact(DELETE) http://localhost:51850/api/contacts/10

Note: For Post Request Response Body also needs to be provided.
Note2: To check all these functionalities you can simply perform CRUD operation from the browser itself as Web Api is consumed in ASP.NET MVC controller using HttpClient.



FOLDER STRUCTURE
This is a WEB API ASP.NET Web Application based on MVC architecture.
Model Folder has two Components:
1)	ContactViewModel - > It maintains the contact data of the application and its objects retrieve and store model state in the database.
2)	Contact.edmx -> It is the ADO.NET Entity Data Model.

Controller Folder has the API Controller (ContactsController inheriting ApiController ) that handles HTTP GET, POST, PUT and DELETE requests also it has a mvc controller (ContactsController inheriting Controller )  which consume Web API using HttpClient.

View Folder has the files with .cshtml extension (Razor) which gets rendered on the browser and is visible to the end user. View folder has further sub folders depending on the number of controller and one shared which is shared among all the controllers.

DataAccessLayer has one interface and one class file implementing that interface. The implementation has codes which deal with data access using Entity framework.

BusinessLayer again has one interface and one class file implementing that interface. The code here defines the business logic required for the application.