# Goals
* support postgres and sql server db at once

## change log
* create new netcore api project
* create new netcore domain project
* link projects


dotnet ef migrations add Initial -s ../api --context SqlDbContext --output-dir Migrations/SqlServerMigrations

### pmc commands
switch to Domain project in pmc or terminal and run
Add-Migration Initial -context SqlDbContext -StartupProject DoubleDbProvider.API -OutputDir Migrations
or
dotnet ef migrations add Initial --context SqlDbContext -s ../api --output-dir Migrations

switch to DomainPG project in pmc or terminal and run
Add-Migration Initial -context PostgresDbContext -StartupProject DoubleDbProvider.API -OutputDir Migrations
or
dotnet ef migrations add Initial --context PostgresDbContext -s ../api --output-dir Migrations


## to read 
[migrations for couple providers](https://docs.microsoft.com/ru-ru/ef/core/managing-schemas/migrations/providers)