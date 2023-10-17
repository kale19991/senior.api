using senior.domain.Primitives;

namespace senior.domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string value)
        => Value = value;

    public string Value { get; }    

    public override string ToString()
        => Value;

    public static implicit operator Name(string value) 
        => new(value);

    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
