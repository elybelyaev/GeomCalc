using GeometricCalculator.Figures;

namespace GeometricFiguresTests;

[TestFixture]
public class TriangleTests
{
    [TestCase(1, 1, 1)]
    [TestCase(3, 4, 5)]
    [TestCase(1.3, 1.2, 1)]
    public void CreateTriangleInstance_ShouldBeSuccessful_OnCorrectSides(double sideA, double sideB, double sideC)
    {
        var createTriangleFunc = () => new Triangle(sideA, sideB, sideC);
        
        createTriangleFunc.Should().NotThrow<ArgumentException>();
    }

    [TestCase(1, 1, -1, TestName = "{m}_OnNegativeSide")]
    [TestCase(1, 0, 1, TestName = "{m}_OnZeroSide")]
    public void CreateTriangleInstance_ShouldThrowException(double sideA, double sideB, double sideC)
    {
        var createTriangleFunc = () => new Triangle(sideA, sideB, sideC);
        
        createTriangleFunc.Should().Throw<ArgumentException>();
    }

    
    [TestCase(1, 1, 3)]
    [TestCase(1, 3, 1)]
    [TestCase(2, 1, 1)]
    public void CreateTriangleInstance_ShouldThrowException_ThenOneSideBiggerThanSumOfOthers(double sideA, double sideB, double sideC)
    {
        var createTriangleFunc = () => new Triangle(sideA, sideB, sideC);
        
        createTriangleFunc.Should()
            .Throw<ArgumentException>()
            .WithMessage("Triangle is not valid: Side with lenght * is greater or equal than the sum of the other two sides");
    }
    
    [TestCase(3, 4, 5)]
    [TestCase(1.25, 3.44, 3.66)]
    public void IsTriangleRight_ShouldReturnTrue_ThenPassedRightTriangleSides(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var isTriangleRightResult = triangle.IsTriangleRight();
        
        isTriangleRightResult.Should().BeTrue();
    }
    
    [TestCase(3, 4, 4, TestName = "{m}AcuteTriangleSides")]
    [TestCase(3, 4, 6, TestName = "{m}ObtuseTriangleSides")]
    [TestCase(1.25, 3.44, 3.67, TestName = "{m}AlmostRightTriangleSides")]
    public void IsTriangleRight_ShouldReturnFalse_ThenPassed(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var isTriangleRightResult = triangle.IsTriangleRight();
        
        isTriangleRightResult.Should().BeFalse();
    }
    
    [Test]
    public void IsTriangleRight_ShouldReturnFalse_ThenPrecisionExtremelyHigh()
    {
        var triangle = new Triangle(1.25, 3.44, 3.66);

        var isTriangleRightResult = triangle.IsTriangleRight(precision: 0.0000001);
        
        isTriangleRightResult.Should().BeFalse();
    }
    
    [TestCase(3, 4, 5, 6, TestName = "{m}_OnEgyptTriangle")]
    [TestCase(1, 1, 1, 0.43, TestName = "{m}_OnEquilateralTriangle")]
    [TestCase(3.5, 3.4, 0.4, 0.67, TestName = "{m}_OnAcuteTriangle")]
    [TestCase(12.3, 6.95, 6.34, 15.46, TestName = "{m}_OnObtuseTriangle")]
    public void CalculateArea_ShouldReturnCorrectResult(double sideA, double sideB, double sideC, double expectedArea)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        var resultArea = triangle.CalculateArea();
        
        resultArea.Should().BeApproximately(expectedArea, 0.01);
    }
}