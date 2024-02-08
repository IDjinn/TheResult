using System.Diagnostics.CodeAnalysis;

namespace TheResult;

public readonly record struct Result<TResult>
{
    private readonly TResult? _value;
    private readonly IReadOnlyCollection<Error> _errors;

    public Result(TResult value)
    {
        _value = value;
        _errors = Array.Empty<Error>();
    }

    public Result(IReadOnlyCollection<Error> errors)
    {
        _errors = errors;
    }

    [MemberNotNullWhen(true, nameof(_value))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool HasValue => _value is not null;

    public bool HasErrors => _errors.Count > 0;
    public TResult? Value => _value;
    public IReadOnlyCollection<Error> Errors => _errors;

    public static Result<TResult> Ok(object value) => new ((TResult)value);
    public static Result<TResult> Error(Error error) => new([error]);
    
    public static implicit operator Result<TResult>(TResult value)
    {
        return new(value);
    }

    public static implicit operator Result<TResult>(List<Error> errors)
    {
        return new(errors.AsReadOnly());
    }

    public static implicit operator Result<TResult>(Error error)
    {
        return new([error]);
    }

    public static implicit operator TResult?(Result<TResult> result)
    {
        return result._value;
    }

    public TReturnValue Match<TReturnValue>(
        Func<TResult, TReturnValue> success,
        Func<IReadOnlyCollection<Error>, TReturnValue> error
    )
    {
        if (HasErrors)
            return error(Errors);

        return success(Value!);
    }
}