# EShopMicroservices

This is my exercise to learn how to implement modern software architectures in ASP.NET such as:
- Microservices
- Vertical Slice Architecture
- Clean Architecture
- CQRS

From the course tutorial [.NET 8 Microservices](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet) by Mehmet Ozkaya.

Thank you very much for sharing your valuable knowledge. It really helps me a lot.

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
- Datastore
  - SQLite RDMBS: embedded SQL database optimized for efficient small-scale data storage

