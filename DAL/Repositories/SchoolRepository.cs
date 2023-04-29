using Domain.Models;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly SchoolContext _schoolContext;

    public SchoolRepository(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
    } 
    
    public async Task<Student?> GetStudentById(int studentId)
    {
        var student = await _schoolContext.Students
                .Where(s => s.StudentId == studentId)
                .FirstOrDefaultAsync()
            ;
        return student;
    }
}