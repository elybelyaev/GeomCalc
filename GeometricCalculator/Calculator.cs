using GeometricCalculator.Figures;

namespace GeometricCalculator;

public static class Calculator
{
    public static double CalculateArea(IWithArea figure) => figure.CalculateArea();
}