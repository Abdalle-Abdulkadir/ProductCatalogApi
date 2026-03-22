# K4U1

# ProductCatalogAPI

## Overview
ProductCatalogAPI is a RESTful API built with ASP.NET Core.
It provides endpoints to manage products, including creation, retrieval, updates, and deletion.

## Purpose
The purpose of this API is to expose product data to clients (e.g., frontend or external systems)
while applying best practices such as validation, paging, and rate limiting.

## Features
- CRUD operations for products (Create, Read, Update, Delete)
- Filtering support using query parameters (minPrice, categoryId)
- Paging support using query parameters (pageNumber, pageSize)
- Validation for incoming data with DataAnnotations
- Rate limiting to control request traffic
- In-memory caching for improved performance

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- InMemory Database
- Swagger (OpenAPI)

## Architecture / Structure

The project follows a clean and layered architecture:
- Controllers → Handle incoming HTTP requests and return responses
- Services → Contain business logic and application rules
- DTOs → Define how data is sent and received
- Models → Represent core domain entities
- Data → Configure database context and data access (EF Core)

## Database Design

The application uses an in-memory database powered by Entity Framework Core.

- Data is stored temporarily and resets when the application restarts
- Entities such as Product, Category, and Supplier define the data structure
- Relationships between entities are configured using EF Core

An ER diagram is provided to illustrate the database structure and relationships.

## API Endpoints

The API exposes the following main endpoints for product management:
- GET /api/Products → Returns products with optional filtering and paging
- POST /api/Products → Creates a new product
- PUT /api/Products/{id} → Updates an existing product
- DELETE /api/Products/{id} → Removes a product

## Swagger

Swagger UI is included for interactive API testing and documentation.
- Start the application
- Open Swagger in the browser
- Choose an endpoint
- Click **Try it out**
- Provide the required input
- Click **Execute** to send the request and inspect the response

## Rate Limiting

Rate limiting is implemented to control request traffic.
- Limit: 2 requests per 10 seconds
- Returns HTTP 429 (Too Many Requests) when exceeded

## How to Run the Project

Follow these steps to run the application:
1. Clone the repository
2. Open the solution in Visual Studio
3. Build and run the project
4. Swagger UI will open automatically in the browser

## Documentation

The project is supported by the following documentation:
- ER Diagram → Visualizes entities and relationships
- README → Explains project structure, setup, and usage
- Screenshots (optional) → Demonstrate API functionality via Swagger

## Reflection

During this project, I learned how to design and build a RESTful API using ASP.NET Core.
I implemented features such as filtering, pagination, validation, caching, and rate limiting.
If I were to improve this project, I would add persistent database support, authentication, and more advanced error handling.

## Author
Abdalle Abdulkadir



