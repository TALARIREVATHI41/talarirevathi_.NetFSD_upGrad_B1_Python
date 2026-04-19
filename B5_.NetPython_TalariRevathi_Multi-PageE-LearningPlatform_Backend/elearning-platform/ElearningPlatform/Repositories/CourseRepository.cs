using Microsoft.EntityFrameworkCore;
public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAll()
{
    return await _context.Courses
        .Include(c => c.Lessons)
        .Include(c => c.Quizzes)
        .AsNoTracking()
        .ToListAsync();
}

    public async Task<Course> GetById(int id)
{
    return await _context.Courses
        .Include(c => c.Lessons)
        .Include(c => c.Quizzes)
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.CourseId == id);
}

    public async Task Add(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

   public async Task Delete(int id)
{
    var course = await _context.Courses.FindAsync(id);

    if (course == null)
        return;

    _context.Courses.Remove(course);
    await _context.SaveChangesAsync();
}
}