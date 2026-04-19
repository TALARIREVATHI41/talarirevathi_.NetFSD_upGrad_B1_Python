using Xunit;

public class QuizLogicTests
{
    [Fact]
    public void Score_ShouldBeCorrect()
    {
        int correct = 3;
        int total = 5;

        int percentage = (correct * 100) / total;

        Assert.Equal(60, percentage);
    }
}