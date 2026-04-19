using ElearningPlatform.DTOs;

namespace ElearningPlatform.Services
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonDto>> GetByCourse(int courseId);
        Task<LessonDto> Create(LessonDto dto);
        Task<bool> Update(int id, LessonDto dto);
        Task<bool> Delete(int id);
    }
}