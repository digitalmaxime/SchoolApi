using AutoMapper;
using Contacts.RepositoryInterfaces;
using MediatR;
using Application.CQRS.Dtos;
namespace Application.CQRS.StudentsDto.Commands.Delete;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, StudentDto?>
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public DeleteStudentCommandHandler(ISchoolRepository schoolRepository, IMapper mapper)
    {
        _schoolRepository = schoolRepository;
        _mapper = mapper;
    }
    
    public async Task<StudentDto?> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _schoolRepository.DeleteStudentById(request.StudentId);
        return _mapper.Map<StudentDto>(student);
    }
}