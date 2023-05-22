using Application.CQRS.Dtos;
using Application.CQRS.StudentAddressDto;
using Application.CQRS.StudentsDto.Commands.Create;
using Application.CQRS.StudentsDto.Commands.Delete;
using Application.CQRS.StudentsDto.Queries.Read;
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
    
    [HttpPost]
    [Route("AddStudentAddress")]
    public async Task<ActionResult<StudentDto?>> AddStudentAddress(AddStudentAddressCommand request)
    {
        var student = await _mediator.Send(request);
        
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student); 
    }

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
}
    