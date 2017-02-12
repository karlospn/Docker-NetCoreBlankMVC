# Docker-NetCoreBlankMVC
Messing with Docker and ASP.NET Core

Docker commands used for creating custom MVC container:
- docker pull microsoft/dotnet:1.0-sdk-projectjson
- docker build -t myname/aspnetcore .
- docker run -p 5000:5000 a6

Docker commands used for running postgresSQL:
- docker pull postgres
- docker run -d --name my-postgres -p 5432:5432 postgres

Linking containers: 
Option 1 
Docker commands for linking MVC container with postgresSQL container:
- docker run -d -p 5000:5000 --link my-postgres:postgres e4

Option 2
Create a network:
 - docker network create --driver bridge isolated_network
Add the desired containers into the network:
- docker run -d -p 5432:5432 --net=isolated_network --name postgres ec
- docker run -d -p 5000:5000 --net=isolated_network --name netcoreapp e4


