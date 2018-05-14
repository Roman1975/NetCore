# Goals
* microservice
* postgree document db
* docker container

## business idea for microservice
* CQRS pattern for storing meter data
* model should be simplified like that: {Id: guid, MeterId : guid, Value: decimal, When: datetime, Scale: byte}

## change log
### database
* suppose we have a postgres installed on mac with homebrew
* add postgesql user: myapi/111 (createuser --pwprompt myapi)
* cretae db: api_doc (createdb -Omyapi -Eutf8 api_doc)
* [optional] log into db: psql -U myapi -W api_doc

### rest api 
* create new webapi project dotnet new webapi
* add model, commad, controller
* build, run ant test with postman
* add package Marten
* add IDocumentStore to services, and injction to CommandController
* build, run ant test with postman

### docker
* pull the required images from Docker Hub, running commands
- docker pull microsoft/dotnet:2.0.0-sdk
- docker pull microsoft/aspnetcore:2.0.0
- docker pull microsoft/aspnetcore-build:2.0.0
- docker pull postges
- docker images
* add docker file
* run PostgreSQL service container: docker run -d --name localdb -e POSTGRES_PASSWORD=supersecret postgres
* add AppDbContext, Migrations, connections string for it
* build my docker image: docker build -t dockerdemo .
* run app: docker run -it -p 5000:80 --link localdb:postgres dockerdemo
to stop container: docker stop localdb
* to remove all stopped containers use: docker container prune 
* usefull commands
- docker system prune
- docker images -a

### caveats
* A container incapsulates its own file system, therefore, when the container is destroyed, we will lose all data. To persist data we'll need to use a docker managed volume and map it to the default location where postges stores db data (in my case, homebrew installation, /usr/local/var/postgres/base).
My commands:
create volume: docker volume create localdbvol
inspect volume: docker volume inspect localdbvol

run postgres (need fix!): docker run -d --name localdb -e POSTGRES_PASSWORD=supersecret postgres -v localdbvol:/usr/local/var/postgres/base
run api: docker run -it -p 5000:80 --link localdb:postgres dockerdemo

stop and clean: docker stop localdb; docker rm localdb; docker container prune; docker volume prune;


### similar examples
[also see example here](https://www.codeproject.com/Articles/1223518/Exploring-ASP-NET-Core-and-Docker-on-MacOS)

