# OpenRMS

~ This document is a work in progress ~

Open RMS is an Open Source project with the intention of delivering a retail management platform that is free to install, use, modify and distribute. The product will continue to evolve as the key technologies mature. 

## Target consumers

The finished product will be aimed primarily at small to medium size business where Excel and Access based solutions are far from ideal.



## Development
Open RMS will be developed on a .Net platform using C# 6.0 developed within a Visual Studio 2015 solution. It will feature key modules like Product Managment, Product Metadata, Product Stock, Location Management (Both Store and Distribution Centre / Hubs) as part of the main open source code but will allow other module to be developed independently and plugged into the main application.

The application will be able to be hosted on public internet servers or private intranet servers.


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
+ Onion / Hexagonal Architecture
+ Dependecy Injection


##### CQRS (Command Query Responsability Segragation) But not with Event Sourcing
The project will use CQRS and have separarate "stacks" for queries reading from the database and commands writing to the database. The QueryStack will use the lightweight [StoredProcedureFramework](https://www.nuget.org/packages/Dibware.StoredProcedureFramework/) for fast querying and [EntityFramework](https://www.nuget.org/packages/EntityFramework/) for the Command Stack.

A simple example of the intended CQRS architecture can be found at this blog post [Using Entity Framework and the Store Procedure Framework To Achieve CQRS](http://www.duanewingett.info/2016/08/02/UsingEntityFrameworkAndTheStoreProcedureFrameworkToAchieveCQRSPart1.aspx)

##### Onion / Hexagonal Architecture

#### Patterns and Practices
##### Domain Driven Design 
##### Dependecy Injection
##### Test First or Test After Test driven development

#### Technologies
##### MVC (to serve master views)
##### Web API (for CRUD)
##### TypeScript
##### Angular 2
##### Sql Server 2016


### Contribution

Anyone is welcome to contribute. You do not need to have retail software experience but it will help. You do not need to be a full stack developer. If you have a strength in HTML and CSS feel free to join. If your preference is in database work, again, you are more than welcome. The project will need a community with a wide skill set yet with deep knowledge of the technologies, patterns and practices. If you can give 30 minutes a day, 30 minutes a week, month or year, you are still as welcome as an equal project member. (I certainly don't have all of the skills or time to carry out this project on my own! - *dibley1973*)
