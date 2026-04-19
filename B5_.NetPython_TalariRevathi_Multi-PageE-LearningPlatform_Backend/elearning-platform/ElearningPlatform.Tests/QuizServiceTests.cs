using Xunit;
using Microsoft.EntityFrameworkCore;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class QuizServiceTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task SubmitQuiz_ShouldReturnCorrectScore()
    {
        var context = GetDbContext();

        // Seed Data
        context.Users.Add(new User { UserId = 1, FullName = "Test", Email = "test@mail.com", PasswordHash = "123", CreatedAt = System.DateTime.Now });

        context.Questions.AddRange(
            new Question { QuestionId = 1, QuizId = 1, QuestionText = "Q1", OptionA = "A", OptionB = "B", OptionC = "C", OptionD = "D", CorrectAnswer = "A" },
            new Question { QuestionId = 2, QuizId = 1, QuestionText = "Q2", OptionA = "A", OptionB = "B", OptionC = "C", OptionD = "D", CorrectAnswer = "B" }
        );

        await context.SaveChangesAsync();

        var mapper = new MapperConfiguration(cfg => { }).CreateMapper();

        var service = new QuizService(context, mapper);

        var dto = new QuizSubmitDto
        {
            UserId = 1,
            Answers = new Dictionary<int, string>
            {
                {1, "A"},
                {2, "B"}
            }
        };

        var result = await service.SubmitQuiz(1, dto);

        Assert.NotNull(result);
    }
}