using GeometricCalculator.Primitives;

namespace GeometricCalculator.Figures;

public class Triangle : IWithArea
{
    private readonly Length _sideA;
    private readonly Length _sideB;
    private readonly Length _sideC;

    private Length Perimeter => _sideA + _sideB + _sideC;
    private Length MaxSideLength => Math.Max(_sideA, Math.Max(_sideB, _sideC));

    public Triangle(Length sideA, Length sideB, Length sideC)
    {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
        CheckIsTriangleValid();
    }

    public double CalculateArea()
    {
        var semiPerimeter = Perimeter / 2;

        return Math.Sqrt(semiPerimeter
                         * (semiPerimeter - _sideA)
                         * (semiPerimeter - _sideB)
                         * (semiPerimeter - _sideC));
    }

    public bool IsTriangleRight(double precision = 0.001)
    {
        var sumOfSideSquares = Math.Pow(_sideA, 2)
                                    + Math.Pow(_sideB, 2)
                                    + Math.Pow(_sideC, 2);
        
        var maxSideSquare = Math.Pow(MaxSideLength, 2);

        return Math.Abs(2 * maxSideSquare - sumOfSideSquares) < precision;
    }

    private void CheckIsTriangleValid()
    {
        if (2 * MaxSideLength >= Perimeter)
            throw new ArgumentException(
                $"Triangle is not valid: Side with lenght {(double) MaxSideLength} is greater or equal than the sum of the other two sides");
    }
}