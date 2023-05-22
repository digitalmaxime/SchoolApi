using MediatR;
using Domain.Models;
using Contacts.RepositoryInterfaces;
using AutoMapper;
using Application.CQRS.Dtos;

namespace Application.CQRS.StudentAddressDto.Queries.Read;

public class GetStudentAddressQueryHandler : IRequestHandler<GetStudentAddressQuery, StudentCityStateDto>
{
    private readonly ISchoolRepository _schoolRepo;
    private readonly IMapper _mapper;

    public GetStudentAddressQueryHandler(ISchoolRepository schoolRepo, IMapper mapper)
    {
        this._schoolRepo = schoolRepo;
        this._mapper = mapper;
    }
    public async Task<StudentCityStateDto> Handle(GetStudentAddressQuery request, CancellationToken cancellationToken)
    {
        var studentAddress = await _schoolRepo.GetAddressByStudentId(request.StudentId);

        return _mapper.Map<StudentCityStateDto>(studentAddress);
    }
}