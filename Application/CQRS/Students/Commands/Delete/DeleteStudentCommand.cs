using MediatR;
using Application.CQRS.Dtos;

namespace Application.CQRS.StudentsDto.Commands.Delete;

public record DeleteStudentCommand(int StudentId) : IRequest<StudentDto?>;