using Domain.Models;

namespace Domain.RepositoryInterfaces;

public interface ISchoolRepository
{
    Task<Student?> GetStudentById(int studentId);
    // Task<Student?> AddStudent(AddStudentDto student);
    // Task<ICollection<Student>> GetAllStudents();
    // Student UpdateStudent(Student student);
    // Task<Student?> DeleteStudentById(int studentId);
    //
    // Task<StudentAddress?> GetAddressByStudentId(int studentId);
    // Task<Student?> AddStudentAddress(AddStudentAddressDto request);
    // Task<Student?> AddCourseToStudent(int studentId, int courseId);
    // Task<Course?> AddStudentToCourse(int studentId, int courseId);
    // Task<Course?> AddCourse(AddCourseDto request);
    // Task<ICollection<Course>> GetAllCourses();
    // Task<Course?> GetCourseById(int id); 
}