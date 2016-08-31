# OpenRMS

~ This document is a work in progress ~

Open RMS is an Open Source project with the intention of delivering a retail management system that is free to install, free to use, free to modify and free to distribute. The aim of the product is to provide system which has key modules which can then be extended with private bespoke modules by developers within retail businessed or additional public modules developed by the wider open source community for the expansion of teh project. The product will continue to evolve as the key technologies mature. 

## Target Consumers

The finished product will be aimed primarily at small to medium size business where Microsoft Excel and Access based solutions are far from ideal.

## Development
Open RMS will be developed on a .Net platform using C# 6.0 and will be developed within a Visual Studio 2015 solution. It will feature key modules like *Product Managment*, *Product Metadata*, *Product Stock*, *Location Management* (both *Store* and *Distribution Centre / Hubs*) as part of the main open source code but will allow other modules to be developed independently and plugged into the main application.

The application will be able to be hosted on public internet servers or private *on-prem* or *off-prem* intranet servers.

### Modules
The application will be split into modules which in most cases will map directly to a "bounded context" within the the problem domain. Although the application will share a single database, each module will have it's own stack from client to data access and databse project. This will allow multiple modules to be worked upon at any one time with limited impact to the other modules. There will be common elements that will be shared accross all modules, like for instance the `SharedKernel` which might contain the base classes for Entities and ValueObjects.

+ Product Managment
+ Product Metadata
+ Product Inventory
+ Location Management
+ Store Metadata
+ Distribution Managment
+ Product in Transit
+ Supply Chain Management

#### ProductManagement
The ProductManagent module will be developed first and once the code, sturcture and format is complete and "signed off" then this will be the template module which all other modules should adhere to. 

### Architecture, Patterns, Technologies and Methodologies
It is intended that the solution will use the following architecture, patterns, technologies and methodologies.

+ Architecture
 + CQRS (Command Query Responsability Segragation) 
 + Onion / Hexagonal Architecture
+ Patterns and Practices
 + Domain Driven Design 
 + Dependecy Injection
 + Test First or Test After Test driven development
 + Repository pattern
 + Unit of Work pattern
 + CQS (Command Query Separation)
+ Technologies
 + MVC (to serve master views)
 + Web API (for CRUD)
 + Angular 2
 + Sql Server 2016
+ Methodologies

#### Architecture

+ CQRS (Command Query Responsability Segragation) 
 + Queries
 + Commands
+ Onion / Hexagonal Architecture

##### CQRS (Command Query Responsability Segregation) 
The project will use CQRS and have separarate "stacks" for queries reading from the database and commands writing to the database. The *Query Stack* will use the lightweight [StoredProcedureFramework](https://www.nuget.org/packages/Dibware.StoredProcedureFramework/) for fast querying and [EntityFramework](https://www.nuget.org/packages/EntityFramework/) for the *Command Stack*.

###### Queries
The *Query Stack* will use a vertical N-Tier *reporting* style of architecture with the *Application Services* referencing the *Read Model*, and the *Read Model* accessing data straight from the database via the *storedProcedureFramework*.

Queries should return either a SearchResult<T> where zero or more results are expected of a type, or a SingleSearchResult<T> where zero or one results are expected. Where arguments are more than one or two in length an object should be defined to hold the parameters. If paging is required then the object should implement the `IPagedQueryParameter` interface which contains the `StartAt` property which indicates where the paging is to start and the `Take` property indicating upto how many records to take. The 

###### Commands
The *Command Stack* will use Onion architecture and a Domain Driven Development practice. Commands should never return a value and should always be defined as a `void` method. Identities for new entities should be created by the domain and assigned to the Entities before inserting into the database. IF the identity for the entity is a *Long Integer* then the High-Low principle may be followed with the next "n" available identities queried from the database. If the identity for the entity is an Guid then the domain can generate it's own.

A simple example of the intended CQRS architecture can be found at this blog post [Using Entity Framework and the Store Procedure Framework To Achieve CQRS](http://www.duanewingett.info/2016/08/02/UsingEntityFrameworkAndTheStoreProcedureFrameworkToAchieveCQRSPart1.aspx)

 

##### Onion / Hexagonal Architecture
At the centre of the onion will be the *Shared.Kernel* which will contain the basic building blocks needed and share accross all bounded contexts. This is where the base `Entity` and `ValueObject` classes will reside. It will also contain any *non*-problem domain objects, for instance the `Maybe<T>` amplifier. Around the *Shared.Kernel* will be wrapped the *Domain.Core*. This is where all of the domain logic should live within the *Domain Entities*, *Value Objects*, *Domain Events* and *Aggregates*. Around this layer will be wrapped the *Domain Services*, *Factories* and *Repositories*. Around this layer will wrap the *Application Services* and the *Integration Tests*.

![Onion Architecture](https://github.com/dibley1973/OpenRMS/blob/master/Documentation/Images/Readme_OnionArchitecture.png?raw=true "Onion Architecture")

#### Patterns and Practices
##### Domain Driven Design 
##### Dependecy Injection
##### Test First or Test After Test driven development
##### Repository pattern
##### Unit of Work pattern
##### CQS (Command Query Separation)
The will be a string drive to ensure a separation of commands and queries in methods. To try and 

#### Technologies
##### MVC (to serve master views)
##### Web API (for CRUD)
##### TypeScript
##### Angular 2
##### Sql Server 2016


### Folder Structure
```
+-- ORMS
|   +-- Documentation
|   +-- Code
|       +-- Product Managment
|       |   +-- 01.Client
|       |   +-- 02.ApplicationServices
|       |   +-- 03.
|       + Product Metadata
|       + Product Inventory
|       + Location Management
|       + Store Metadata
|       + etc.
|       +-- Shared
|           + SharedKernal
```

### Namespacing
Even though abreviations in code are evil the base namespace will be `ORMS`, standing for "Open Retail Management Service".

Examples of the name spacing for the *Shared Kernel* and the *Product Management* module are shown below.

```
ORMS
ORMS.Shared.SharedKernel
ORMS.Shared.SharedKernel.UnitTests
ORMS.ProductManagement.ApplicationServices
ORMS.ProductManagement.ApplicationServices.IntegrationTests
ORMS.ProductManagement.Domain.Services
ORMS.ProductManagement.Domain.Entities
ORMS.ProductManagement.Domain.Repositories
```

### Documentation
+ Format
+ Location

#### Format
Where appropriate project documentation should be in markdown with a suffix of ".md"

#### Location
Where possible project documentation should be in appropriately nested folders with the "Documentation" folder inside the solution root. The exception to this is the "README.md" and "LICENCE" files which should remain at the root.

### Contribution

Anyone is welcome to contribute. You do not need to have retail software experience but it will help. You do not need to be a full stack developer. If you have a strength in HTML and CSS feel free to join. If your preference is in database work, again, you are more than welcome. The project will need a community with a wide skill set yet with deep knowledge of the technologies, patterns and practices. If you can give 30 minutes a day, 30 minutes a week, month or year, you are still as welcome as an equal project member. (I certainly don't have all of the skills or time to carry out this project on my own! - *dibley1973*)
