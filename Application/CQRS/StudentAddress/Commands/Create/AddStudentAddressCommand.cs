using Application.CQRS.Dtos;
using MediatR;

namespace Application.CQRS.StudentAddressDto;

public record AddStudentAddressCommand(int StudentId, string Address, string City, string State) : IRequest<StudentDto>;