using TheResult;
using TheResult;

namespace TheResult.Testings;

public class ResultTestings
{
    [Fact]
    public void should_return_value()
    {
        var result = new ResultOf<bool>(true);
        Assert.True(result.HasValue);
        Assert.True(result.Value);
    }
    [Fact]
    public void should_return_errors()
    {
        var result = new ResultOf<String>(new []{new Error { Code = "wtf"}});
        Assert.False(result.HasValue);
        Assert.Null(result.Value);
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);
        Assert.Equal("wtf", result.Errors.First().Code);
    }
}