using AutoMapper;
using MediatR;

using Contacts.RepositoryInterfaces;
using Application.CQRS.Dtos;

namespace Application.CQRS.StudentsDto.Queries.Read;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDto>>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public GetAllStudentsQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
    {
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }
    
    public async Task<List<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _schoolRepository.GetAllStudents();
        return _mapper.Map<List<StudentDto>>(students);
    }
}