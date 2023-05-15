using MediatR;

namespace Application.CQRS.Students.Queries.Delete;

public record DeleteStudentCommand(int StudentId) : IRequest<StudentDto?>;