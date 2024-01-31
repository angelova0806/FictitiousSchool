
#Fictitious School Application Form API

This project is a backend application for a fictitious school. It allows companies to apply for various courses offered by the school. The application handles the storage of course applications, including details about the company and its participants.

##Features
Submission of course applications by companies.
Each application includes course ID, course date, company details, and participant details.
Backend API for creating and retrieving applications.
Data persistence using Entity Framework with a code-first approach.

##Getting Started
Prerequisites
.NET 6.0 SDK
Entity Framework Core CLI
Azure Account (for deployment and database hosting)


##Installation
1.Clone the repository
git clone https://github.com/angelova0806/FictitiousSchool.git

2.Navigate to the project directory
cd fictitious-school

3.Restore dependencies
dotnet restore

4.Apply migrations to create the database
dotnet ef database update

5.Run the application
dotnet run

API Documentation
The API is documented using Swagger. After running the application, you can access the Swagger UI at https://localhost:7005/swagger/index.html.

#Testing
Run the unit tests using the following command:
dotnet test

#Deployment
The application is designed for deployment on Azure. Follow these steps to deploy:

-Create an Azure App Service
-Set up Azure SQL Database
-Deploy the application using Azure DevOps or GitHub Actions
-Update the connection string in Azure to point to the Azure SQL Database

Live demo URL: https://fictitiousschool20240131124902.azurewebsites.net/swagger/index.html

#Architecture and Design Choices
-The project uses a clean architecture with a focus on separation of concerns.
-Entity Framework Core is used for ORM with a code-first approach.
-Design patterns like Repository Pattern are implemented for data access, Dependency Injection integral to ASP.NET Core, is used for managing repositories and services, enhancing flexibility and making unit testing more straightforward.

Services and repositories are registered Program.cs, allowing runtime resolution of dependencies and aligning the application with modern software design principles.