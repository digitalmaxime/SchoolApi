using AutoMapper;
using Contacts.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Students.Queries.Create;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto?>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(ISchoolRepository schoolRepository , IMapper mapper)
    {
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }

    public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _schoolRepository.GetStudentById(request.StudentId);
        return _mapper.Map<StudentDto>(student);
    }
}