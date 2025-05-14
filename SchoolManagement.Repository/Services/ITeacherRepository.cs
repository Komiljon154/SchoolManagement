using SchoolManagement.DataAccess.Entities;
using SchoolManagement.DataAccess.Helpers;

namespace SchoolManagement.Repository.Services;

public interface ITeacherRepository
{
    Task<int> AddTeacherAsync(Teacher teacher);
    Task<Teacher> GetTeacherByIdAsync(int teacherId);
    Task<PaginatedList<Teacher>> GetPaginatedTeachersAsync(
        int pageNumber, int pageSize,
        bool includeStudents = false,
        bool includeClasses = false);
    Task UpdateTeacherAsync(Teacher teacher);
    Task DeleteTeacherAsync(int teacherId);
}