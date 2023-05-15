using Application.CQRS.Students;
using Application.CQRS.Students.Queries;
using Application.CQRS.Students.Queries.Delete;
using Domain.Models;
using Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("GetStudentById")]
    public async Task<ActionResult<StudentDto>> GetStudentById(int studentId)
    {
        StudentDto? student = await _mediator.Send(new GetStudentByIdQuery(studentId));
        
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }
    
    [HttpGet]
    [Route("GetAllStudents")]
    public async Task<ActionResult<List<StudentDto>>> GetAllStudents()
    {
        var students = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(students);
    }
    
    // public Student UpdateStudent(Student student)
    // {
    //     throw new NotImplementedException();
    // }
    
    
    [HttpDelete]
    [Route("DeleteStudent")]
    public async Task<ActionResult<StudentDto>>  DeleteStudentById(int studentId)
    {
        StudentDto? deletedStudent = await _mediator.Send(new DeleteStudentCommand(studentId));
        
        if (deletedStudent == null)
        {
            return NotFound();
        }

        return Ok(deletedStudent); 
    }
}
    