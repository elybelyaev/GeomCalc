using GeometricCalculator;
using GeometricCalculator.Figures;

namespace GeometricFiguresTests;

public class CalculatorTests
{
    [Test]
    public void CalculateArea_ShouldBeSuccessful_OnAnyIWithArea()
    {
        var figuresWithArea = new IWithArea[] {new Circle(5), new Triangle(1, 1, 1)};

        foreach (var figure in figuresWithArea)
        {
            var areaFunc = () => Calculator.CalculateArea(figure);

            areaFunc.Should().NotThrow();
        }
    }
}