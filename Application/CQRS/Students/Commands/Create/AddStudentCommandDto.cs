using MediatR;

using Application.CQRS.Dtos;

namespace Application.CQRS.StudentsDto.Commands.Create;

public record AddStudentCommandDto(string StudentName, DateTime DateOfBirth, int? GradeId) : IRequest<StudentDto>;