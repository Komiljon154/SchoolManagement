using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

public class TeacherClassConfiguration : IEntityTypeConfiguration<TeacherClass>
{
    public void Configure(EntityTypeBuilder<TeacherClass> builder)
    {
        builder.ToTable("TeacherClasses");

        builder.HasKey(tc => new { tc.TeacherID, tc.ClassID });

        builder.HasOne(tc => tc.Teacher)
               .WithMany(t => t.TeacherClasses)
               .HasForeignKey(tc => tc.TeacherID).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(tc => tc.Class)
               .WithMany(c => c.ClassTeachers)
               .HasForeignKey(tc => tc.ClassID).OnDelete(DeleteBehavior.Cascade);
    }
}
