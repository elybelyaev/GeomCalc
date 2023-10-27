using GeometricCalculator.Primitives;

namespace GeometricCalculator.Figures;

public class Circle : IWithArea
{
    private readonly Length _radius;

    public Circle(Length radius)
    {
        _radius = radius;
    }

    public double CalculateArea()
    {
        var area = Math.PI * _radius * _radius;

        if (double.IsPositiveInfinity(area))
            throw new Exception("The resulting area is too large");

        return area;
    }
}