using MediatR;

namespace Application.CQRS.Students.Queries.Create;

public record GetStudentByIdQuery(int StudentId) : IRequest<StudentDto?>;