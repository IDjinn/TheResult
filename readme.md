# TheResult

Rust-like result return (value or error) handled written in c#

### Usage
```csharp
public Result<string> Hello()
{
    return Result<string>.Ok("World!");
}
```
