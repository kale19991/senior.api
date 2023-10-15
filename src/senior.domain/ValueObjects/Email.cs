using senior.domain.Primitives;

namespace senior.domain.ValueObjects;

public sealed class Email : ValueObject
{
    private Email(string value)
        => Value = value;

    public string Value { get; }    

    public override string ToString()
        => Value;

    public static implicit operator Email(string value) 
        => new(value);

    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }        
}