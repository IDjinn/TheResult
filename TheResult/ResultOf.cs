using System.Diagnostics.CodeAnalysis;

namespace TheResult;

public readonly record struct ResultOf<TResult>
{
    private readonly TResult? _value;
    private readonly IReadOnlyCollection<Error> _errors;

    public ResultOf(TResult value)
    {
        _value = value;
        _errors = Array.Empty<Error>(); 
    }
    
    public ResultOf(IReadOnlyCollection<Error> errors)
    {
        _errors = errors;
    }
    
    [MemberNotNullWhen(true, nameof(_value))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool HasValue => _value is not null;

    public bool HasErrors => _errors.Count > 0;
    public TResult? Value => _value;
    public IReadOnlyCollection<Error> Errors => _errors;
    public static implicit operator ResultOf<TResult>(TResult value)
    {
        return new(value);
    }
    
    public static implicit operator ResultOf<TResult>(List<Error> errors)
    {
        return new(errors.AsReadOnly());
    }
    
    public static implicit operator TResult?(ResultOf<TResult> result)
    {
        return result._value;
    }
}