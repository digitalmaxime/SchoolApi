using MediatR;
using Application.CQRS.Dtos;


namespace Application.CQRS.StudentAddressDto.Queries.Read;

public record GetStudentAddressQuery(int StudentId) : IRequest<StudentCityStateDto>;