using ElearningPlatform.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace ElearningPlatform.Services
{
    public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public LessonService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
       public async Task<IEnumerable<LessonDto>> GetByCourse(int courseId)
{
    var lessons = await _context.Lessons
    .AsNoTracking() // ✅ FIX
    .Where(l => l.CourseId == courseId)
    .ToListAsync();

    return _mapper.Map<List<LessonDto>>(lessons);
}

        public async Task<LessonDto> Create(LessonDto dto)
{
    // ✅ CHECK COURSE EXISTS
    var course = await _context.Courses.FindAsync(dto.CourseId);
    if (course == null)
        throw new Exception("Invalid CourseId");

    var lesson = _mapper.Map<Lesson>(dto);

    _context.Lessons.Add(lesson);
    await _context.SaveChangesAsync();

    return _mapper.Map<LessonDto>(lesson);
}

        public async Task<bool> Update(int id, LessonDto dto)
{
    var lesson = await _context.Lessons.FindAsync(id);
    if (lesson == null) return false;

    lesson.Title = dto.Title;
    lesson.Content = dto.Content;
    lesson.CourseId = dto.CourseId;
    lesson.OrderIndex = dto.OrderIndex;
    await _context.SaveChangesAsync();
    return true;
}

        public async Task<bool> Delete(int id)
{
    var lesson = await _context.Lessons.FindAsync(id);
    if (lesson == null) return false;

    _context.Lessons.Remove(lesson);
    await _context.SaveChangesAsync();

    return true;
}
    }
}