using Domain.Models;
using MediatR;

namespace Application.CQRS.Students.Queries;

public record GetStudentByIdQuery(int StudentId) : IRequest<StudentDto?>;