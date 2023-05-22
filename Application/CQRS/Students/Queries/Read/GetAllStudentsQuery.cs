using MediatR;
using Application.CQRS.Dtos;

namespace Application.CQRS.StudentsDto.Queries.Read;

public record GetAllStudentsQuery() : IRequest<List<StudentDto>>;