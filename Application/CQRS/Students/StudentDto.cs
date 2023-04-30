namespace Application.CQRS.Students;

public class StudentDto
{
    public string StudentName { get; set; } = string.Empty;
    public bool IsAdult { get; set; } 

    public StudentDto()
    {
        
    }
    public StudentDto(string studentName, bool isAdult)
    {
        StudentName = studentName;
        IsAdult = isAdult;
    }
} 