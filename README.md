<h2>Entity Framework Core</h2>

<h3>Create New MySql Connection</h3>
In MySql press + sign to create a new MySql Connection

Create a new query and setup a password

`select current_user();
set password = 'test123';`

In the Api layer add the connectionStr to the appSettings.json

```
"ConnectionStrings": {
    "DefaultConnection":"Server=localhost;Port=3306;Uid=root;Database=School;Pwd=test123;SslMode=Required"
}
```



<h3>/Api Nugets</h3>

``dotnet package add Microsoft.EntityFrameworkCore.Design``

(because ``/Infrastructure`` has entity framework core stuff, but Api holds the connection str)

<h3>/DAL Nugets</h3>

``dotnet package add Microsoft.EntityFrameworkCore``

``dotnet package add  MySql.EntityFrameworkCore ``

<h3>Cmd Line</h3>

In a multiple projects solution (DDD), you need to specify which project has DbContext and which project is the startup project

Run the following commands at root folder level

``
$ dotnet ef migrations add init --project DAL --startup-project Api
``

``
$ dotnet ef database update --project DAL --startup-project Api
``

---

<h2>MediatR</h2>
add nuget package to both ``/Api`` and ``/DAL`` projects

```$ dotnet add package mediatR```

<h2>AutoMapper</h2>
under ``/Application`` add AutoMapper nuget package

```$ dotnet add package AutoMapper```

In ``/Application/Configuration`` where you want the DI to happen import the following nuget 

```$  dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection ```

*Note: you might want to setup AutoMapper under ``/DAL`` as well if you intend to map externally fetched object to domain object*

In `ConfigureApplicationService` set :

``services.AddAutoMapper(cfg => cfg.AddProfile(typeof(StudentMappingProfile)));``

or 

``services.AddAutoMapper(typeof(StudentMappingProfile));``

this way, DI for AutoMapper will be enabled and configured with the `: Profile` classes