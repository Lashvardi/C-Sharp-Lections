using LMS.Models;
using LMS.Models.Relationships;
using LMS.Models.Students;
using LMS.Models.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LMS.Data;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Principal> Principals { get; set; }
    public DbSet<SubjectTeacher> SubjectTeachers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectTeacher>()
            .HasKey(st => new { st.SubjectId, st.TeacherId });

        modelBuilder.Entity<Subject>()
            .HasMany(s => s.SubjectTeachers)
            .WithOne(st => st.Subject)
            .HasForeignKey(st => st.SubjectId);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.SubjectTeachers)
            .WithOne(st => st.Teacher)
            .HasForeignKey(st => st.TeacherId);


        modelBuilder.Entity<Principal>()
            .HasOne(p => p.School)
            .WithOne(s => s.Principal)
            .HasForeignKey<Principal>(p => p.SchoolId);

        modelBuilder.Entity<School>()
            .HasMany(s => s.Teachers)
            .WithOne(t => t.School)
            .HasForeignKey(t => t.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}