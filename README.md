# MiniShop Web Application
## Project Overview
This web application is developed using C# .NET 7 for the backend and Angular for the frontend. It follows the Onion Architecture (Clean Architecture) to ensure modularity, separation of concerns, and maintainability. The project utilizes various technologies and tools, including Visual Studio, Visual Studio Code, PostgreSQL, Docker, DBeaver, Angular, Azure Storage, and JWT token authentication.

## Technologies Used
### Backend (c#)
- Framework: .NET 7
- Database: PostgreSQL
- ORM: EntityFramework Core
- Containerization: Docker
- Logging: Serilog
- Design Patterns: CQRS, Generic Repository
- Real-time Communication: SignalR
- Authentication: JWT Token

### Frontend (Angular)
- UI Libraries: AdminDashboard (Material), Bootstrap, JQuery
- Notification Libraries: AlertifyJS (Admin), Ngx-toastr (UI)
- File Upload: Ngx-file-drop
- Loading Spinner: NgxSpinner

## Project Structure
The project follows the Onion Architecture (Clean Architecture) to promote maintainability and loose coupling between layers.

### Onion Architecture Overview
1) Domain Layer:
* Core layer containing entities, value objects, enumerations, and domain-specific exceptions.
2) Repository & Service Interfaces (Core Layer):
* Abstract layer between the domain and application layers.
* Definition of all service interfaces (e.g., IRepository, IXService).
* Loose coupling for data access.
3) Persistence Layer:
* Responsible for database operations and data transformation logic.
* Implementation of repository interfaces from the core layer.
* Includes DbContext, migrations, configurations, seeding, and concrete repository classes.
4) Infrastructure Layer:
* Integrates with the persistence layer but handles operations outside the database.
* Services, operations, and processes not directly related to database access.
* Examples: Email/SMS service, notifications, payment processing.
5) Presentation Layer:
* The layer where users interact with the application.
* Can include Web App, Web API, MVC, etc.

### SignalR and JWT Token
* SignalR
  - Real-time communication is achieved using SignalR.
  - SignalR hubs are implemented in the infrastructure layer.
* JWT Token
  - JSON Web Tokens (JWT) are used for authentication.
  - Users receive a JWT token upon successful authentication.
  - The token is included in the headers of subsequent requests for authorization.

### CORS Policy
Cross-Origin Resource Sharing (CORS) is crucial when the client application is running on a different origin (protocol, host, or port) than the server. Browsers enforce the Same-Origin Policy to prevent unauthorized access. The CORS policy is applied to ensure that requests from the client are permitted based on the target site's policies.



# Getting Started
Follow these steps to set up and run the MiniShop web application:
1) Clone the Repository:
   ```bash
   git clone https://github.com/berkgonencc/minishop.git 

2) Build the Docker Container:
   ```bash
   docker run --name PostgreSQL -p 5432:5432 -e POSTGRES_PASSWORD=your-password -d postgres

3) Install dotnet ef global tools:
   ```bash
   dotnet tool install --global dotnet-ef
   
2) Backend Setup:
   - Open the solution in Visual Studio.
   - Configure the database connection in the 'appsettings.json' file.
   - Run Entity Framework migrations to create the database:
     ```bash
     dotnet ef migrations add mig_1
     dotnet ef database update

3) Frontend Setup:
   - Navigate to the 'MiniShopClient' directory.
   - Install Angular dependencies:
     ```bash
     npm install
   - Run the Angular application:
     ```bash
     ng serve

4) Launch the Application:
   - Start the backend server.
     ```bash
     dotnet restore
     dotnet build
     dotnet run


