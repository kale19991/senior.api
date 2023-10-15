namespace senior.domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetValues();

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject && ValuesAreEqual(valueObject);
    }

    public override int GetHashCode()
    {
        return GetValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetValues().SequenceEqual(other.GetValues());
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
}
