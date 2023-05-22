using AutoMapper;
using Contacts.RepositoryInterfaces;
using MediatR;
using Application.CQRS.Dtos;
namespace Application.CQRS.StudentsDto.Commands.Create;

public class AddStudentCommandHandler : IRequestHandler<AddStudentCommandDto, StudentDto>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public AddStudentCommandHandler(ISchoolRepository schoolRepository, IMapper mapper)
    {
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }
    
    public async Task<StudentDto> Handle(AddStudentCommandDto request, CancellationToken cancellationToken)
    {
        var newStudent = await _schoolRepository.AddStudent(request.StudentName, request.DateOfBirth, request.GradeId);
        return _mapper.Map<StudentDto>(newStudent);
    }
}