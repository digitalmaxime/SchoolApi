using Domain.Models;

namespace Contacts.RepositoryInterfaces;

public interface ISchoolRepository
{
    Task<Student?> GetStudentById(int studentId);
    // Task<Student?> AddStudent(AddStudentDto student);
    // Student UpdateStudent(Student student);
    //
    // Task<StudentAddress?> GetAddressByStudentId(int studentId);
    // Task<Student?> AddStudentAddress(AddStudentAddressDto request);
    // Task<Student?> AddCourseToStudent(int studentId, int courseId);
    // Task<Course?> AddStudentToCourse(int studentId, int courseId);
    // Task<Course?> AddCourse(AddCourseDto request);
    // Task<ICollection<Course>> GetAllCourses();
    // Task<Course?> GetCourseById(int id); 
    Task<ICollection<Student>> GetAllStudents();
    Task<Student?> DeleteStudentById(int studentId);
    Task<Student?> AddStudent(string studentName, DateTime dateOfBirth, int? GradeId);
}