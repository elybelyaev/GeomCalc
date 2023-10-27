using GeometricCalculator.Primitives;

namespace GeometricCalculator.Figures;

public class Circle : IWithArea
{
    private readonly Length _radius;

    public Circle(Length radius)
    {
        _radius = radius;
    }

    public double CalculateArea() => Math.PI * _radius * _radius;
}