using MediatR;

namespace Application.CQRS.Students.Queries;

public record GetAllStudentsQuery() : IRequest<List<StudentDto>>;