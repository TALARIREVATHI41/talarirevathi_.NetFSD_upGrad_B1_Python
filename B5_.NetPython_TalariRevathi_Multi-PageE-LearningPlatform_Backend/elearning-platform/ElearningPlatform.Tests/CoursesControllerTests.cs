using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ElearningPlatform.Controllers;
using ElearningPlatform.Services;
using ElearningPlatform.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CoursesControllerTests
{
    private readonly Mock<ICourseService> _serviceMock;
    private readonly CoursesController _controller;

    public CoursesControllerTests()
    {
        _serviceMock = new Mock<ICourseService>();
        _controller = new CoursesController(_serviceMock.Object);
    }

    // ✅ GET ALL
    [Fact]
    public async Task GetAll_ShouldReturnOk()
    {
        _serviceMock.Setup(s => s.GetAll())
            .ReturnsAsync(new List<CourseDto>());

        var result = await _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    // ✅ GET BY ID (FOUND)
    [Fact]
    public async Task Get_ShouldReturnCourse_WhenExists()
    {
        _serviceMock.Setup(s => s.GetById(1))
            .ReturnsAsync(new CourseDto { CourseId = 1, Title = "Test", Description = "Desc" });

        var result = await _controller.Get(1);

        Assert.IsType<OkObjectResult>(result);
    }

    // ✅ GET BY ID (NOT FOUND)
    [Fact]
    public async Task Get_ShouldReturnNotFound_WhenNotExists()
    {
        _serviceMock.Setup(s => s.GetById(1))
            .ReturnsAsync((CourseDto)null);

        var result = await _controller.Get(1);

        Assert.IsType<NotFoundResult>(result);
    }

    // ✅ CREATE COURSE
    [Fact]
    public async Task Create_ShouldReturnCreated()
    {
        var dto = new CourseDto { CourseId = 1, Title = "Test", Description = "Desc" };

        _serviceMock.Setup(s => s.Create(dto))
            .ReturnsAsync(dto);

        var result = await _controller.Create(dto);

        Assert.IsType<CreatedAtActionResult>(result);
    }

    // ✅ DELETE COURSE
    [Fact]
    public async Task Delete_ShouldReturnOk_WhenDeleted()
    {
        _serviceMock.Setup(s => s.Delete(1))
            .ReturnsAsync(true);

        var result = await _controller.Delete(1);

        Assert.IsType<OkObjectResult>(result);
    }
}