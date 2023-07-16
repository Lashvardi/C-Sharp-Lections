using System.ComponentModel.DataAnnotations;
using LMS.Models.Subjects;
using Microsoft.EntityFrameworkCore;

namespace LMS.Models.Relationships;

[Keyless]
public class SubjectTeacher
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
        
    // Relationships
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
}