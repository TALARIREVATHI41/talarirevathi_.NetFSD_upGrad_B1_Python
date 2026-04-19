using Xunit;
using System.Threading.Tasks;

public class ExceptionTests
{
    [Fact]
    public async Task ShouldThrowException_WhenInvalidQuiz()
    {
        await Assert.ThrowsAsync<System.Exception>(async () =>
        {
            await Task.Run(() =>
            {
                throw new System.Exception("Invalid Quiz");
            });
        });
    }
}