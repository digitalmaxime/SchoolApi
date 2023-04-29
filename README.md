<h2>Entity Framework Core</h2>
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

<h3>Program.cs configuration</h3>
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();


