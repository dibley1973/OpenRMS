# OpenRMS

~ This document is a work in progress ~

Open RMS is an Open Source project with the intention of delivering a retail management platform that is free to install, use, modify and distribute. The product will continue to evolve as the key technologies mature. 

## Target consumers

The finished product will be aimed primarily at small to medium size business where Excel and Access based solutions are far from ideal.



## Development
Open RMS will be developed on a .Net platform using C# 6.0 developed within a Visual Studio 2015 solution. It will feature key modules like Product Managment, Product Metadata, Product Stock, Location Management (Both Store and Distribution Centre / Hubs) as part of the main open source code but will allow other module to be developed independently and plugged into the main application.

The application will be able to be hosted on public internet servers or private intranet servers.

### Modules
The application will be split into modules which in most cases will map directly to a "bounded context" within the domain. Although the application will share a single database, each module will have it's own stack from client to data access and databse project. This will allow multiple modules to be worked upon at any one time with limited impact to the other modules. There will be common elements that will be shared accross all modules, like for instance the `SharedKernel` which might contain the base classes for Entities and ValueObjects.

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
 + CQRS (Command Query Responsability Segragation) But not with Event Sourcing
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

+ CQRS (Command Query Responsability Segragation) But not with Event Sourcing
 + Queries
 + Commands
+ Onion / Hexagonal Architecture

##### CQRS (Command Query Responsability Segragation) But not with Event Sourcing
The project will use CQRS and have separarate "stacks" for queries reading from the database and commands writing to the database. The QueryStack will use the lightweight [StoredProcedureFramework](https://www.nuget.org/packages/Dibware.StoredProcedureFramework/) for fast querying and [EntityFramework](https://www.nuget.org/packages/EntityFramework/) for the Command Stack.

###### Queries
Queries should return either a SearchResult<T> where zero or more results are expected of a type, or a SingleSearchResult<T> where zero or one results are expected. Where arguments are more than one or two in length an object should be defined to hold the parameters. If paging is required then the object should implement the `IPagedQueryParameter` interface which contains the `StartAt` property which indicates where the paging is to start and the `Take` property indicating upto how many records to take.

###### Commands
Commands should never return a value and should always be defined as a `void` method.

A simple example of the intended CQRS architecture can be found at this blog post [Using Entity Framework and the Store Procedure Framework To Achieve CQRS](http://www.duanewingett.info/2016/08/02/UsingEntityFrameworkAndTheStoreProcedureFrameworkToAchieveCQRSPart1.aspx)

##### Onion / Hexagonal Architecture

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
+--- ORMS
|    +--- Documentation
|    +--- Product Managment
|    |    +--- 01.Client
|    |    +--- 02.ApplicationServices
|    |    +--- 03.
|    + Product Metadata
|    + Product Inventory
|    + Location Management
|    + Store Metadata
|    + etc.
|    +--- Shared
|         + SharedKernal

### Documentation
+ Format
+ Location

#### Format
Where appropriate project documentation should be in markdown with a suffix of ".md"

#### Location
Where possible project documentation should be in appropriately nested folders with the "Documentation" folder inside the solution root. The exception to this is the "README.md" and "LICENCE" files which should remain at the root.

### Contribution

Anyone is welcome to contribute. You do not need to have retail software experience but it will help. You do not need to be a full stack developer. If you have a strength in HTML and CSS feel free to join. If your preference is in database work, again, you are more than welcome. The project will need a community with a wide skill set yet with deep knowledge of the technologies, patterns and practices. If you can give 30 minutes a day, 30 minutes a week, month or year, you are still as welcome as an equal project member. (I certainly don't have all of the skills or time to carry out this project on my own! - *dibley1973*)
