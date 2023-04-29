using MediatR;

namespace Application.CQRS.Students.Queries;

public record GetStudentByIdQuery(int StudentId) : IRequest<Domain.Models.Student?>;