using Application.Configuration;
using Application.CQRS.Students.Queries;
using Application.CQRS.Students.Queries.Create;
using DAL.Configuration;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureInfrastructureService(builder.Configuration);
builder.Services.ConfigureApplicationService(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetStudentByIdQuery>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hey man, checkout '/swagger'!");

app.MapGet("/student/{studentId}/loves/{bookId}", 
    (int studentId, int bookId) => $"The student id {studentId} loves book id {bookId}");


app.Run();
