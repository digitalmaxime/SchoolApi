using MediatR;

namespace Application.CQRS.Students.Queries.Create;

public record GetAllStudentsQuery() : IRequest<List<StudentDto>>;