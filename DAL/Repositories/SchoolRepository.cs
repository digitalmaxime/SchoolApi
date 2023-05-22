using Contacts.RepositoryInterfaces;
using Domain.Models;
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
                .Include(s => s.StudentAddress)
                .FirstOrDefaultAsync()
            ;
        return student;
    }
    
    public async Task<ICollection<Student>> GetAllStudents()
    {
        var students = await _schoolContext.Students
            // .Include(s => s.Grade)
            .Include(s => s.StudentAddress)
            // .Include(s => s.Courses)
            .ToListAsync();

        return students;
    }
    
    public async Task<Student?> DeleteStudentById(int studentId)
    {
        var student = await _schoolContext.Set<Student>()
            .FindAsync(studentId);

        if (student != null)
        {
            _schoolContext.Students.Remove(student);
            await _schoolContext.SaveChangesAsync();
        }

        return student;
    }
    
    public async Task<Student?> AddStudent(string studentName, DateTime dateOfBirth, int? GradeId)
    {
        // var grade = await _schoolContext.Grades.FindAsync(request.GradeId);

        // if (grade == null) return null;

        var student = new Student
        {
            StudentName = studentName,
            DateOfBirth = dateOfBirth
            // Grade = grade
        };

        _schoolContext.Add(student);
        await _schoolContext.SaveChangesAsync();

        return student;
    }

    public async Task<StudentAddress?> GetAddressByStudentId(int studentId)
    {
        var studentAddress = await _schoolContext.StudentAddresses
                .FirstOrDefaultAsync(s => s.Student.StudentId == studentId)
            ;
        return studentAddress;
    }

    public async Task<Student?> AddStudentAddress(int studentId, string address, string city, string state)
    {
        var student = await _schoolContext.Students.FindAsync(studentId);
        if (student == null)
        {
            return null;
        }


        var studentAddress = new StudentAddress
        {
            Address = address,
            City = city,
            State = state,
            Student = student,
        };

        var oldStudentAddress = await _schoolContext.StudentAddresses.Where(s => s.StudentId == studentId).FirstOrDefaultAsync();
        if (oldStudentAddress != null) {
            oldStudentAddress = studentAddress;            
            _schoolContext.Update(oldStudentAddress);
            await _schoolContext.SaveChangesAsync();
            return student;
        }

        _schoolContext.Update(studentAddress);
        await _schoolContext.SaveChangesAsync();

        return student;
    }
}