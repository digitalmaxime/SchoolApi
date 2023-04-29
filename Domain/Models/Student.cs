namespace Domain.Models;

public class Student
{
    // scalar Properties
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;

    // public DateTime? DateOfBirth { get; set; }
    // public byte[]? Photo { get; set; }
    // public decimal? Height { get; set; }
    // public float? Weight { get; set; }

    // Reference Navigation Properties (reference property)
    // public Grade Grade { get; set; } = new ();
    // public int GradeId { get; set; }  // PK of Grade (here Student is the dependent entity, it needs a GradeId to live)

    // public ICollection<Course> Courses { get; set; } = new List<Course>();
    // public StudentAddress? StudentAddress { get; set; } // 1 to 1 relationship (Student is the independent entity, it can live without an address)
 
}