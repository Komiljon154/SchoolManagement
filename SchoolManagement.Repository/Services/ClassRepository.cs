using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.Repository.Services;

public class ClassRepository : IClassRepository
{
    private readonly MainContext mainContext;

    public ClassRepository(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<long> AddClassAsync(Class addingClass)
    {
        await mainContext.Classes.AddAsync(addingClass);
        await mainContext.SaveChangesAsync();
        return addingClass.ClassID;
    }

    public async Task DeleteClassAsync(long id)
    {
        var clas = await GetClassByIdAsync(id);
        mainContext.Classes.Remove(clas);
        await mainContext.SaveChangesAsync();
    }

    public async Task<List<Class>> GetAllClass(bool studentClass, bool teacherClass, int skip, int take)
    {
        // Eager loading uchun Include'lardan foydalanish
        IQueryable<Class> query = mainContext.Classes
            .Include(c => c.ClassStudents)
            .Include(c => c.ClassTeachers)
            .AsQueryable();

        // Agar ikkalasi false bo‘lsa, bo‘sh list qaytaramiz
        if (!studentClass && !teacherClass)
            return new List<Class>();

        // Filterlash
        if (studentClass && !teacherClass)
        {
            query = query.Where(c => c.ClassStudents.Any());
        }
        else if (!studentClass && teacherClass)
        {
            query = query.Where(c => c.ClassTeachers.Any());
        }
        else if (studentClass && teacherClass)
        {
            query = query.Where(c => c.ClassStudents.Any() || c.ClassTeachers.Any());
        }

        // Skip va Take
        var result = await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return result;
    }

    public async Task<Class> GetClassByIdAsync(long id)
    {
        var clas = await mainContext.Classes.FirstOrDefaultAsync(x => x.ClassID == id);
        if (clas == null)
        {
            throw new Exception("this id not found");
        }
        return clas;
    }

    public async Task UpdateClassAsync(Class updatingClass)
    {
        mainContext.Classes.Update(updatingClass);
        await mainContext.SaveChangesAsync();
    }
}
