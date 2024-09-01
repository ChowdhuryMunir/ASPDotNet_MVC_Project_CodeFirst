# ASP.NET MVC Project - Code First Approach

This repository contains an ASP.NET MVC application built using the .NET Framework, demonstrating the Code-First approach with Entity Framework. The project implements a Master-Detail design pattern and supports six different data types, showcasing effective data management and relational data handling in a web application.

## Features

- **Master-Detail Design Pattern**: Manage and display relationships between master and detail entities.
- **Code-First Approach**: Define the database schema using C# classes and let Entity Framework create the database schema.
- **Six Data Types**: Incorporates various data types for comprehensive data handling.
- **CRUD Operations**: Full support for Create, Read, Update, and Delete operations.
- **ASP.NET MVC**: Utilizes the Model-View-Controller pattern for a well-structured and maintainable application.
- **Data Validation**: Ensures data integrity and accuracy with validation rules.

## Technologies Used

- **ASP.NET MVC**: Framework for building web applications using the Model-View-Controller architecture.
- **Entity Framework**: ORM for managing data access with a Code-First approach.
- **SQL Server**: Database system used for storing and managing data.
- **.NET Framework**: Platform used for developing and running the application.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/) with support for ASP.NET and .NET Framework
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database system

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ChowdhuryMunir/ASPDotNet_MVC_Project_CodeFirst.git
   cd ASPDotNet_MVC_Project_CodeFirst
   ```

2. **Open the Project**
   - Open the solution file (`.sln`) in Visual Studio.

3. **Update Database Connection String**
   - Open the `web.config` file and update the connection string:
     ```xml
     <connectionStrings>
       <add name="DefaultConnection" connectionString="Server=your_server;Database=your_database;User Id=your_user;Password=your_password;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. **Build the Project**
   - Build the project in Visual Studio to restore NuGet packages and compile the application.

5. **Apply Migrations**
   - Open the Package Manager Console in Visual Studio and run:
     ```powershell
     Update-Database
     ```

6. **Run the Application**
   - Start the application using Visual Studio. It will be accessible at `http://localhost:your_port`.

## Project Structure

- **Models**: Contains entity classes representing the data schema and relationships.
- **Data**: Includes the DbContext and configuration for Entity Framework.
- **Controllers**: Implements MVC controllers for handling user interactions and data processing.
- **Views**: Contains Razor views for displaying data and user interfaces.
- **wwwroot**: Static files like CSS, JavaScript, and images.

## Application Features

- **Master Entity Management**:
  - **Create Master Entity**: Add new master records.
  - **Read Master Entity**: View master records.
  - **Update Master Entity**: Modify existing master records.
  - **Delete Master Entity**: Remove master records.

- **Detail Entity Management**:
  - **Create Detail Entity**: Add new detail records linked to master records.
  - **Read Detail Entity**: View detail records.
  - **Update Detail Entity**: Modify existing detail records.
  - **Delete Detail Entity**: Remove detail records.

- **Data Types**:
  - Handles six different data types across various entities to demonstrate versatile data management.

## Usage

Navigate to `http://localhost:your_port` in your web browser to access the application. Use the interface to interact with master and detail entities and perform CRUD operations.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push the branch (`git push origin feature/your-feature`).
5. Open a pull request with a description of your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact [MunirchowdhurySaif](https://github.com/chowdhuryMunir).
