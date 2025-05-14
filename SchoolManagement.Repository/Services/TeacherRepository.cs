using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess;
using SchoolManagement.DataAccess.Entities;
using SchoolManagement.DataAccess.Helpers;

namespace SchoolManagement.Repository.Services;

public class TeacherRepository : ITeacherRepository
{
    private readonly MainContext mainContext;
    public TeacherRepository(MainContext context)
    {
        mainContext = context;
    }

    public async Task<int> AddTeacherAsync(Teacher teacher)
    {
        if (teacher == null)
        {
            throw new Exception("Teacher is null");
        }
        await mainContext.Teachers.AddAsync(teacher);
        return await mainContext.SaveChangesAsync().ContinueWith(t => teacher.TeacherID);
    }

    public async Task DeleteTeacherAsync(int teacherId)
    {
        var teacher = mainContext.Teachers.FirstOrDefault(t => t.TeacherID == teacherId);
        if (teacher == null)
        {
            throw new Exception("Teacher not found");
        }
        mainContext.Teachers.Remove(teacher);
        await mainContext.SaveChangesAsync();
    }
    public async Task<PaginatedList<Teacher>> GetPaginatedTeachersAsync(
        int pageNumber, int pageSize,
        bool includeStudents = false,
        bool includeClasses = false)
    {
        IQueryable<Teacher> query = mainContext.Teachers;

        if (includeStudents)
        {
            query = query.Include(t => t.TeacherStudents);
        }

        if (includeClasses)
        {
            query = query.Include(t => t.TeacherClasses);
        }

        return await PaginatedList<Teacher>.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
    {
        var teacher = await mainContext.Teachers.FirstOrDefaultAsync(t => t.TeacherID == teacherId);
        if (teacher == null)
        {
            throw new Exception("Teacher not found");
        }
        return teacher;
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        var existingTeacher = mainContext.Teachers.FirstOrDefault(t => t.TeacherID == teacher.TeacherID);
        if (existingTeacher == null)
        {
            throw new Exception("Teacher not found");
        }

        mainContext.Teachers.Update(teacher);
        await mainContext.SaveChangesAsync();
    }
}
