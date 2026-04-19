using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAll();
        Task<CourseDto> GetById(int id);
        Task<CourseDto> Create(CourseDto dto);
        Task<bool> Update(int id, CourseDto dto);
        Task<bool> Delete(int id);
    }
}