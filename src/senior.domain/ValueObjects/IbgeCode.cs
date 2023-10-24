using senior.domain.Primitives;
using System.Text.Json.Serialization;

namespace senior.domain.ValueObjects;

public sealed class IbgeCode : ValueObject
{
    public IbgeCode(string value)
        => Value = value;

    public string Value { get; }    

    public override string ToString()
        => Value;

    public static implicit operator IbgeCode(string value) 
        => new(value);

    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
