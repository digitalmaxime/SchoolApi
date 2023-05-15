using MediatR;

namespace Application.CQRS.Students.Commands.Create;

public record AddStudentCommandDto(string StudentName, DateTime DateOfBirth, int? GradeId) : IRequest<StudentDto>;