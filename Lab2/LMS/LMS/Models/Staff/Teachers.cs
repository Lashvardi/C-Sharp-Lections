using LMS.Models.Relationships;
using LMS.Models.Subjects;

namespace LMS.Models;

public class Teacher
{
    public int Id { get; set; }
    public Guid SchoolId { get; set; }
    public string Name { get; set; }

    // Relationships
    public School School { get; set; }
    public ICollection<SubjectTeacher> SubjectTeachers { get; set; }
}