namespace GeometricCalculator.Primitives;

public class Length
{
    private readonly double _value;
    
    public Length(double value)
    {
        if (value <= 0)
            throw new ArgumentException($"Lenght value must be greater than 0, but found {value}");
        _value = value;
    }
    
    public static implicit operator double(Length length) => length._value;

    public static implicit operator Length(double value) => new(value);
}