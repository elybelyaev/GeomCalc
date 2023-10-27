using GeometricCalculator.Figures;

namespace GeometricFiguresTests;

[TestFixture]
public class CircleTests
{
    [TestCase(1, TestName = "{m}IntegerRadius")]
    [TestCase(1.1, TestName = "{m}FractionalRadius")]
    public void CreateCircleInstance_ShouldBeSuccessful_OnPositive(double radius)
    {
        var createCircleFunc = () => new Circle(radius);
        
        createCircleFunc.Should().NotThrow<ArgumentException>();
    }

    [TestCase(0, TestName = "{m}_OnZeroRadius")]
    [TestCase(-1, TestName = "{m}_OnNegativeRadius")]
    public void CreateCircleInstance_ShouldThrowException(double radius)
    {
        var createCircleFunc = () => new Circle(radius);
        
        createCircleFunc.Should().Throw<ArgumentException>();
    }
    
    [TestCase(3, 28.27, TestName = "{m}_OnIntegerRadius")]
    [TestCase(1.5, 7.06, TestName = "{m}_OnFractionalRadius")]
    public void CalculateArea_ShouldReturnCorrectResult(double radius, double expectedArea)
    {
        var circle = new Circle(radius);

        var resultArea = circle.CalculateArea();
        
        resultArea.Should().BeApproximately(expectedArea, 0.01);
    }
    
    [Test]
    public void CalculateArea_ShouldThrowException_OnBigValues()
    {
        var circle = new Circle(double.MaxValue);
        var calculateFunc = () => circle.CalculateArea();
        
        calculateFunc.Should()
            .Throw<Exception>()
            .WithMessage("The resulting area is too large");
    }
}