using Xunit;
using Moq;
using AutoMapper;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CourseServiceTests
{
    [Fact]
    public async Task GetAll_ShouldReturnCourses()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var mockMapper = new Mock<IMapper>();

        var courses = new List<Course> { new Course { CourseId = 1, Title = "Test", Description = "Desc" } };

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(courses);
        mockMapper.Setup(m => m.Map<IEnumerable<CourseDto>>(courses))
                  .Returns(new List<CourseDto> { new CourseDto { CourseId = 1, Title = "Test", Description = "Desc" } });

        var service = new CourseService(mockRepo.Object, mockMapper.Object);

        var result = await service.GetAll();

        Assert.NotNull(result);
    }
}