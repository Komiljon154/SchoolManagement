using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

public class TeacherStudentConfiguration : IEntityTypeConfiguration<TeacherStudent>
{
    public void Configure(EntityTypeBuilder<TeacherStudent> builder)
    {
        builder.ToTable("TeacherStudents");

        builder.HasKey(ts => new { ts.TeacherID, ts.StudentID });

        builder.HasOne(ts => ts.Teacher)
               .WithMany(t => t.TeacherStudents)
               .HasForeignKey(ts => ts.TeacherID);

        builder.HasOne(ts => ts.Student)
               .WithMany(s => s.TeacherStudents)
               .HasForeignKey(ts => ts.StudentID);
    }
}
