using System.ComponentModel.DataAnnotations;
using LMS.Models.Relationships;
using LMS.Models.Students;

namespace LMS.Models.Subjects;

public class Subject
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public int TeacherId { get; set; }

    // Relationships
    public Teacher Teacher { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<SubjectTeacher> SubjectTeachers { get; set; }

}