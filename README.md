CV Application Documentation


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

1. Install Docker on your machine.
2. Open the project in Visual Studio Code and navigate to the root directory of the project in your terminal.
3. Build the Docker images and run the project by running the command: `docker-compose up`
   - The MongoDB database will be running on port 27017.
   - The .NET API will be available on `https://localhost:8081`.
4. Open your web browser and navigate to `http://localhost:8081/swagger` to access the Swagger UI for the API.
5. Run the Blazor WebAssembly app "Delgado.Run" with HTTPS, preferably on port 7155, as this port is allowed in the CORS settings.
6. The homepage "Delgado.Run" is set to look for the API at `http://localhost:8081`.


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
