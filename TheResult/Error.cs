namespace TheResult;

public readonly record struct Error
{
    public required string Code { get; init; }
    public string? Message { get; init; }
}