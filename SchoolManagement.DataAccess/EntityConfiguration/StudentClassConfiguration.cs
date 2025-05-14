using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

public class StudentClassConfiguration : IEntityTypeConfiguration<StudentClass>
{
    public void Configure(EntityTypeBuilder<StudentClass> builder)
    {
        builder.ToTable("StudentClasses");

        builder.HasKey(sc => new { sc.StudentID, sc.ClassID });

        builder.HasOne(sc => sc.Student)
               .WithMany(s => s.StudentClasses)
               .HasForeignKey(sc => sc.StudentID);

        builder.HasOne(sc => sc.Class)
               .WithMany(c => c.ClassStudents)
               .HasForeignKey(sc => sc.ClassID);
    }
}
