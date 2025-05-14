using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.Repository.Services;

public interface IClassRepository
{
    Task<long> AddClassAsync(Class addingClass);
    Task DeleteClassAsync(long id);
    Task<Class> GetClassByIdAsync(long id);
    Task UpdateClassAsync(Class updatingClass);
    Task<List<Class>> GetAllClass(bool studentClass,bool teacherClass,int skip,int take);
}
