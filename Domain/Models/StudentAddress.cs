using System.Text.Json.Serialization;

namespace Domain.Models;

public class StudentAddress
{
	public int StudentAddressId { get; set; }
	public int StudentId { get; set; } // Student id as PK
	public string Address { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;

	[JsonIgnore]
	public Student Student { get; set; } // reference navigation property
	
}