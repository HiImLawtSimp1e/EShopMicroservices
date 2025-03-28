# EShopMicroservices

This is my exercise to learn how to implement modern software architectures in ASP.NET such as:
- Microservices
- Vertical Slice Architecture
- Clean Architecture
- CQRS

From the course tutorial [.NET 8 Microservices](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet) by Mehmet Ozkaya.

Thank you very much for sharing your valuable knowledge. It really helps me a lot.

## 🚀 Quick start

To run this project on your computer, you need to have .NET 8 package, MS SQL, PostgreSQL, Docker, Redis, and RabbitMQ installed.

1.  **Step 1.**
    Clone the project
    ```sh
    git clone https://github.com/HiImLawtSimp1e/EShopMicroservices.git
    ``` 
## FrontEnd
- ASP.NET Razor Pages with Refit HTTP Client Factory
- Bootstrap

## BackEnd API Gateways
- YARP API Gateway

## Catlog Service
- Patterns & Principles
  - Vertical Slice Architecture
  - CQRS
  - Mediator Pattern: for implement CQRS
  - Dependency Injection
  - Minimal APIs
  - ORM Pattern
- Library
  - MediatR for CQRS: This library simplifies the implementation of the CQRS pattern.
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
  - Marten ORM for PostgreSQL Interaction: Use PostgreSQL as a Document DB. It leverages PostgreSQL's JSON capabilities for storing, querying, and managing documents.
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
- Datastore
  - PostgreSQL used as a Document database (Marten ORM): By using PostgreSQL's JSON column features, Marten ORM transforms PostgreSQL into `.NET Transactional Document DB`

## Basket Service
- Patterns & Principles
  - Vertical Slice Architecture
  - CQRS
  - Mediator Pattern: Used for implement CQRS
  - Repository Pattern
  - Proxy Pattern: Used for implement Redis cache
  - Decorator Pattern: Used for implement Redis cache
  - Read-Aside Pattern: Caching strategy
  - Dependency Injection
  - Minimal APIs
  - ORM Pattern
- Library
  - MediatR for CQRS: This library simplifies the implementation of the CQRS pattern.
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
  - Marten ORM for PostgreSQL Interaction: Use PostgreSQL as a Document DB. It leverages PostgreSQL's JSON capabilities for storing, querying, and managing documents.
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
  - Scrutor for implement decorator pattern: By registering decorator in DI Container
  - gRPC for inter service communication
  - Redis for distributed cache
  - MassTransit for RabbitMQ operations
- Datastore
  - PostgreSQL used as a Document database (Marten ORM): By using PostgreSQL's JSON column features, Marten ORM transforms PostgreSQL into `.NET Transactional Document DB`
  - Redis distrubuted cache

## Discount Service
- Patterns & Principles
  - N-Layered Architecture
  - gRPC Protobuf files Endpoints: for service communication
  - ORM Pattern
- Library
  - EF Core ORM
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
-Datastore
  - SQLite RDMBS: embedded SQL database optimized for efficient small-scale data storage

## Order Service
- Common Patterns & Principles
  - SOLID
  - Clean Architecture
  - Tactical Domain-Driven Design: Oriented Microservice 
  - Dependency Injection

#### Core Layers ( Business Logic )
1. Domain Layer
- Patterns & Principles
  - Tactical Domain-Driven Design 
    - DDD Objects (Entities, Value Objects, Aggregates & Aggregate Root)
    - Rich-Domain Model
    - Domain Events & Integration Events
- ⚠️ Library
  - ⚠️ Depends on EF Core: for the ORM to properly recognize Value Objects (instead of treating them as Entities)
  - ⚠️ Depends on MediatR: for Domain Events

2. Application Layer
- Patterns & Principles
  - CQRS
  - Mediator Pattern: for implement CQRS
- ⚠️ Library
  - ⚠️ Depends on MediatR: Using this library is the quickest and simplest way to implement the CQRS pattern
  - ⚠️ Depends on Mapster: for Object Mapping
  - ⚠️ Depends on FluentValidation: for Input Validation

#### Periphery Layers ( Infrastructure & External Systems )

1. Infrastructure Layer
- Patterns & Principles
  - Repository Pattern
  - ORM Pattern
  - Domain-Driven Design
    - Mapping DDD Objects to ORM Entities
    - Raise & Dispatch Domain: using EF Core ORM & MediatR
- Library
  - EF Core ORM
      - Complex Types: suport Value Objects in DDD
      - EF Aggregate Root Entities
- Datastore
  - MSSQL RBMDS 

2. Presentation Layer (API Layer)
- Patterns & Principles
  - Minimal APIs
- Library
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
