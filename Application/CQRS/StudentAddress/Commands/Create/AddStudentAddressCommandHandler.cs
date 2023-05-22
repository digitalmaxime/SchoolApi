using Application.CQRS.Dtos;
using AutoMapper;
using Contacts.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.StudentAddressDto;

public class AddStudentAddressCommandHandler : IRequestHandler<AddStudentAddressCommand, StudentDto>
{
    private readonly ISchoolRepository _schoolRepo;
    private readonly IMapper _mapper;

    public AddStudentAddressCommandHandler(ISchoolRepository schoolRepo, IMapper mapper)
    {
        this._schoolRepo = schoolRepo;
        this._mapper = mapper;
    }

    public async Task<StudentDto> Handle(AddStudentAddressCommand request, CancellationToken cancellationToken)
    {
        var student = await _schoolRepo.AddStudentAddress(request.StudentId, request.Address, request.City, request.State);
        return _mapper.Map<StudentDto>(student);
    }
}