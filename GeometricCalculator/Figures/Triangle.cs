using GeometricCalculator.Primitives;

namespace GeometricCalculator.Figures;

public class Triangle : IWithArea
{
    private readonly Lenght _sideA;
    private readonly Lenght _sideB;
    private readonly Lenght _sideC;

    private Lenght Perimeter => _sideA + _sideB + _sideC;
    private Lenght MaxSideLenght => Math.Max(_sideA, Math.Max(_sideB, _sideC));

    public Triangle(Lenght sideA, Lenght sideB, Lenght sideC)
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

    public bool IsTriangleRight(double eps = 0.001)
    {
        var sumOfSideSquares = Math.Pow(_sideA, 2)
                                    + Math.Pow(_sideB, 2)
                                    + Math.Pow(_sideC, 2);
        
        var maxSideSquare = Math.Pow(MaxSideLenght, 2);

        return Math.Abs(2 * maxSideSquare - sumOfSideSquares) < eps;
    }

    private void CheckIsTriangleValid()
    {
        if (2 * MaxSideLenght > Perimeter)
            throw new ArgumentException(
                $"Triangle is not valid: Side with lenght {MaxSideLenght} is greater than the sum of the other two sides");
    }
}