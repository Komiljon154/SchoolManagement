using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Entities;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers")
               .HasKey(t => t.TeacherID);

        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.Age).IsRequired();
        builder.Property(t => t.Subject).IsRequired().HasMaxLength(20);

        builder.HasMany(t => t.TeacherClasses)
               .WithOne(tC => tC.Teacher)
               .HasForeignKey(tC => tC.TeacherID);

        builder.HasMany(t => t.TeacherStudents)
               .WithOne(tC => tC.Teacher)
               .HasForeignKey(tC => tC.TeacherID);
    }
}
