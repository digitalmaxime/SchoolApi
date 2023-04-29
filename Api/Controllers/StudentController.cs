using Application.CQRS.Students.Queries;
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
    public async Task<ActionResult<Student>> GetStudentById(int studentId)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(studentId));

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }
}