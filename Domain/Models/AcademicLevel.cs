using System.Text.Json.Serialization;

namespace Domain.Models;

public class AcademicLevel
{
    public int AcademicLevelId { get; set; }
    public DegreeLevel GradeLevel { get; set; }

    // [NotMapped]
    // [JsonIgnore]
    // public ICollection<Student?> Students { get; set; } // generic collection navigation property

    public AcademicLevel()
    {
        this.GradeLevel = DegreeLevel.Undergraduate;
        // this.Students = new List<Student?>(0);
    }
}