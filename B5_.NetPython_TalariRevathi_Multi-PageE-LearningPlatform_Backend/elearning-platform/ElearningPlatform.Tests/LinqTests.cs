using Xunit;
using System.Collections.Generic;
using System.Linq;

public class LinqTests
{
    [Fact]
    public void ShouldFilterHighScores()
    {
        var scores = new List<int> { 40, 60, 80 };

        var result = scores.Where(s => s > 50).ToList();

        Assert.Equal(2, result.Count);
    }
}