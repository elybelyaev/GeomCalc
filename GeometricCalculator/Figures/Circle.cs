using GeometricCalculator.Primitives;

namespace GeometricCalculator.Figures;

public class Circle : IWithArea
{
    private readonly Lenght _radius;

    public Circle(Lenght radius)
    {
        _radius = radius;
    }

    public double CalculateArea() => Math.PI * _radius * _radius;
}