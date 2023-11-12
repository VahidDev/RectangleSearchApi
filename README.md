# Project description
The application is a web-based API designed to perform coordinate-based searches within a set of rectangles. The core functionality involves accepting an array of coordinates as input and returning a corresponding list of rectangles from a populated database. Each rectangle in the database is defined by coordinates and/or dimensions.

# Used Patterns and Technologies:

## Architecture Patterns:

Onion Architecture: The project follows the Onion Architecture, organizing code in layers for enhanced modularity and maintainability.
Design Pattern:

Repository Pattern: The application employs the Repository pattern, providing a structured way to manage data access and storage.

Unit Tests: 
The inclusion of unit tests ensures the reliability and correctness of the application, contributing to overall code quality.
Containerization:

Docker: The entire application is containerized using Docker, facilitating seamless deployment and portability across environments.

Database Connectivity:
SQL Server in Container: The application establishes a connection to a SQL Server, which is containerized for efficient management and deployment.

Programming Paradigm:
Aspect-Oriented Programming (AOP): AOP is implemented to ensure the integrity of the model sent to the API endpoint, enhancing maintainability and readability of the codebase.