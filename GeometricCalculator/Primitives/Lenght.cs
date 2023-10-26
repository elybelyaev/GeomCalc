namespace GeometricCalculator.Primitives;

public class Lenght
{
    private readonly double _value;
    
    public Lenght(double value)
    {
        if (value <= 0)
            throw new ArgumentException($"Lenght value must be greater than 0, but found {value}");
        _value = value;
    }
    
    public static implicit operator double(Lenght lenght) => lenght._value;

    public static implicit operator Lenght(double value) => new(value);
}