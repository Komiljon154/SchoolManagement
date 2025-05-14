using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes");

        builder.HasKey(c => c.ClassID);

        builder.Property(c => c.ClassName).IsRequired();

        builder.HasMany(c => c.ClassTeachers)
            .WithOne(tc => tc.Class)
            .HasForeignKey(tc => tc.ClassID);

        builder.HasMany(c => c.ClassStudents)
            .WithOne(sc => sc.Class)
            .HasForeignKey(sc => sc.ClassID);
    }
}