using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Students.Queries;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Domain.Models.Student?>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetStudentByIdQueryHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    public async Task<Domain.Models.Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _schoolRepository.GetStudentById(request.StudentId);
        return student;
    }
}