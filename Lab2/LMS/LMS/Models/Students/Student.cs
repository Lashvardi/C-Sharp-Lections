using System.ComponentModel.DataAnnotations;
using LMS.Models.Subjects;

namespace LMS.Models.Students;

public class Student
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public ICollection<Subject> Subjects { get; set; }

    public decimal Gpa { get; set; }
    
    // Relationship
    public Parent Parent { get; set; }
}