CV Application Documentation

Description
The cv web application is a .NET Core application that serves as a personal CV website. 
It uses a MongoDB database to store CV data, and provides an admin interface for managing the CV data. 
The front-end is built with Blazor WebAssembly, and the back-end is a .NET Core Web API.

Functionality

The application provides the following functionality:
•	Displaying CV data on the home page.
•	An admin page for managing CV data, including personal information, education, experience, skills, and projects.
•	The ability to add, update, and delete CV data.


Running the Application with Docker

To run the application with Docker, follow these steps:
1.	Install Docker on your machine.
2.	Navigate to the root directory of the project in your terminal.
3.	Build the Docker image by running the command: docker build -t delgado-app .
4.	Run the Docker image by running the command: docker run -p 8000:80 delgado-app
5.	Open your web browser and navigate to http://localhost:8080](http://localhost:8080/swagger/index.html to view the application.

Technical Choices

The application is built with .NET Core for its  cross-platform capabilities,
and support for web APIs and MongoDB integration. Blazor WebAssembly was chosen for the front-end to enable a single-page 
application.
The application uses the MongoDB.Driver library for connecting to MongoDB and performing database operations.
The application is containerized using Docker.


Tools and Libraries

•	.NET Core: The framework used to build the application.
•	Blazor WebAssembly: The framework used for the front-end.
•	MongoDB.Driver: The library used for MongoDB integration.
•	Docker: The platform used to containerize the application.
•	GitHub: The platform used for version control.
