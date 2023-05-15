using AutoMapper;
using Contacts.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Students.Queries.Create;

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