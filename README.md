# MiniShop Web Application
## Project Overview
This web application is developed using C# .NET 7 for the backend and Angular for the frontend. It follows the Onion Architecture (Clean Architecture) to ensure modularity, separation of concerns, and maintainability. The project utilizes various technologies and tools, including Visual Studio, Visual Studio Code, PostgreSQL, Docker, DBeaver, Angular, and Azure Storage.

## Technologies Used
### Backend (c#)
- Framework: .NET 7
- Database: PostgreSQL
- ORM: EntityFramework Core
- Containerization: Docker
- Logging: Serilog
- Design Patterns: CQRS, Generic Repository

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


# Getting Started
Follow these steps to set up and run the MiniShop web application:
1) Clone the Repository:
   git clone https://github.com/yourusername/minishop.git 
   ```bash
