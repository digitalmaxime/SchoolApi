using Application.CQRS.Students;
using Application.CQRS.Students.Commands.Create;
using Application.CQRS.Students.Commands.Delete;
using Application.CQRS.Students.Queries;
using Application.CQRS.Students.Queries.Create;
using Domain.Models;
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
    
    // [HttpGet]
    // [Route("GetAddressByStudentById")]
    // public async Task<ActionResult<Student>> GetAddressByStudentById(int studentId)
    // {
    //     var studentAddress = await _mediator.Send(new GetStudentAddressQuery(studentId));
    //
    //     if (studentAddress == null)
    //     {
    //         return NotFound("No student address found..");
    //     }
    //
    //     return Ok(studentAddress);
    // }
    
    [HttpPost]
    [Route("AddStudent")]
    public async Task<ActionResult<Student>> AddStudent(AddStudentCommandDto request)
    {
        var student = await _mediator.Send(request);

        if (student == null)
        {
            return BadRequest("Error while creating new student, maybe Grade is not defined");
        }

        return Ok(student);
    }
    
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
    