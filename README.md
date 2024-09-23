# Documentation for manual migrations
The database structure is for an activity monitor application.
It consists of an Activity table, with 

# Instructions for manual migrations
Run Run1-Run3 scripts to run all migrations

# Manual rollback plan
Run RB1-RB4 to rollback migrations

It is not advisable to rollback RB2, RB3, RB4 as core functionality will be removed.    
It is however possible...

# Documentation for EF Core migrations
Download and install NuGet packages:
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
```

# Instructions for EF Core migrations
Change `dbConnection` under `ConnectionStrings` in `AppSettings.json`, to suit your particular setup.

Use `dotnet-ef` to update database with the migrations:
```
dotnet-ef database update
```

## Adding new migrations
Use the following command to add new migrations.
```
dotnet-ef migrations add [Name of migration]
```
Repeat first step to update the database.

# EF Core rollback plan
To rollback migrations, use...:
```
dotnet-ef migrations remove
```
...to rollback one migration at a time, and update database accordingly.
