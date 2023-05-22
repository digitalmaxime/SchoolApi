using MediatR;
using Application.CQRS.Dtos;

namespace Application.CQRS.StudentsDto.Queries.Read;

public record GetStudentByIdQuery(int StudentId) : IRequest<StudentDto?>;