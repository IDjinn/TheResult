namespace TheResult;

public readonly record struct Error(string Code, string? Message = null)
{
    public static Error NotFound(string? message = null, string? code = null) =>
        new(code ?? "generic.error.not-found", message);
    public static Error Failure(string? message = null, string? code = null) =>
        new(code ?? "generic.error.failure", message);
    public static Error Validation(string? message = null, string? code = null) =>
        new(code ?? "generic.error.validation", message);
}