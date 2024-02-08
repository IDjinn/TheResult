using TheResult;
using TheResult;

namespace TheResult.Testings;

public class ResultTestings
{
    [Fact]
    public void should_return_value()
    {
        var result = new Result<bool>(true);
        Assert.True(result.HasValue);
        Assert.True(result.Value);
    }
    [Fact]
    public void should_return_errors()
    {
        var result = new Result<String>([new Error { Code = "wtf"}]);
        Assert.False(result.HasValue);
        Assert.Null(result.Value);
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);
        Assert.Equal("wtf", result.Errors.First().Code);
    }
    
    [Fact]
    public async Task try_match_success()
    {
        var result = new Result<bool>(true) ;
        
        await result.Match(success =>
        {
            Assert.True(success);
            return ValueTask.CompletedTask;
        }, failure =>
        {
            Assert.Empty(failure);
            return ValueTask.CompletedTask;
        });
    }
    
    
    [Fact]
    public async Task try_match_failure()
    {
        var result = new Result<bool>([new Error { Code = "wtf"}]) ;
        
        await result.Match(success =>
        {
            Assert.False(success);
            return ValueTask.CompletedTask;
        }, failure =>
        {
            Assert.NotEmpty(failure);
            return ValueTask.CompletedTask;
        });
    }
}