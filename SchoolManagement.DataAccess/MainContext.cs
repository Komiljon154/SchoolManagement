using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Entities;
using SchoolManagement.DataAccess.EntityConfiguration;

namespace SchoolManagement.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<TeacherClass> TeacherClasses { get; set; }
    public DbSet<TeacherStudent> TeacherStudents { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherStudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherClassConfiguration());
        modelBuilder.ApplyConfiguration(new StudentClassConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}