namespace TheResult;

public static class ResultExtensions
{
    public static Result<T> Ok<T>(T value) => new (value);
    public static Result<T> Ok<T>(object value) => new ((T)value);
    public static Result<T> Error<T>(Error error) => new([error]);
    public static Result<T> Error<T>(Error[] error) => new(error);
}