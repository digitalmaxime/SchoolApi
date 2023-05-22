using Domain.Models;

namespace Application.CQRS.Dtos;

public class StudentDto
{
    public string StudentName { get; set; } = string.Empty;
    public bool IsAdult { get; set; }
    public StudentCityStateDto? Location { get; set; }


    public StudentDto()
    {

    }

    public StudentDto(string studentName, bool isAdult)
    {
        StudentName = studentName;
        IsAdult = isAdult;
    }
}