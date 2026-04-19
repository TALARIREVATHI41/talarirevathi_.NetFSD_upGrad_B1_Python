using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Result> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasMany(u => u.Courses)
        .WithOne(c => c.User)
        .HasForeignKey(c => c.CreatedBy);

    modelBuilder.Entity<Course>()
        .HasMany(c => c.Lessons)
        .WithOne(l => l.Course);

    modelBuilder.Entity<Course>()
        .HasMany(c => c.Quizzes)
        .WithOne()
        .HasForeignKey(q => q.CourseId);

    // ✅ FIX 1
    modelBuilder.Entity<Result>()
        .HasOne(r => r.User)
        .WithMany(u => u.Results)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.NoAction);

    // ✅ FIX 2
    modelBuilder.Entity<Result>()
        .HasOne(r => r.Quiz)
        .WithMany()
        .HasForeignKey(r => r.QuizId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Quiz>()
    .HasMany(q => q.Questions)
    .WithOne()
    .HasForeignKey(q => q.QuizId);
}
}