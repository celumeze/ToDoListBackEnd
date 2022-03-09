ToDoList
The application was developed by adopting the Onion Architecture for allowing separation of concerns between the various layers of the application.

The Core component of the application is composed of the Domain entities and the abstractions of the ToDoList functions which makes use of the repository data access pattern so that data access logic is not coupled within the UI layer.

Also the use of the Mediator Pattern was adopted for ensuring loose coupling of the various services responsible for the business logic and avoiding direct communication between the business objects. This is implemented by the use of the MediatR library.

Furthermore, in other to ensure reads and writes are logically seperated and can be scaled independently, a simple CQRS pattern was adopted within the Application Layer where the business logic is implemented.

The infrastructure layer is the layer where concrete implementation of the abstractions defined in the Application Layer are defined. The DI Container (ASP.NET) is configured also in this layer as well as all data persistence functionalities.

Given more time I will ensure that integration tests are carried out on the persistence components for example ensuring that Audit properties (CreatedDate, ModifiedDate etc) are actually being set in any CRUD operations.

----Running the Application
1. Navigate to the root of the application on command prompt and enter docker-compose up.
2. Navigate to https://localhost:5001/swagger on web browser to test endpoints.
