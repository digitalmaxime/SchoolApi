using MediatR;

namespace Application.CQRS.Students.Commands.Delete;

public record DeleteStudentCommand(int StudentId) : IRequest<StudentDto?>;