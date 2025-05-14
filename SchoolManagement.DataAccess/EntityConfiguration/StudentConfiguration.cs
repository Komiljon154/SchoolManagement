using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.EntityConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("ClassStudents");

        builder.HasKey(s => s.StudentID);

        builder.Property(s => s.FirstName).
            IsRequired(true).HasMaxLength(30);

        builder.Property(s => s.LastName).
            IsRequired(true).HasMaxLength(30);

        builder.Property(s => s.Age).
            IsRequired(true);

        builder.Property(s => s.Grade).
            IsRequired(true).HasMaxLength(10);

        builder.HasMany(s => s.TeacherStudents)
            .WithOne(ts => ts.Student)
            .HasForeignKey(ts => ts.StudentID);

        builder.HasMany(s => s.StudentClasses).
            WithOne(sC => sC.Student).
            HasForeignKey(sC => sC.StudentID);
    }
}
