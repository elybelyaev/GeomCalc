using GeometricCalculator.Primitives;

namespace GeometricFiguresTests;

[TestFixture]
public class LengthTests
{
    [TestCase(50, TestName = "{m}IntegerValue")]
    [TestCase(1.5, TestName = "{m}FractionalValue")]
    public void CreateLenghtInstance_ShouldBeSuccessful_OnPositive(double value)
    {
        var createLengthFunc = () => new Length(value);
        
        createLengthFunc.Should().NotThrow<ArgumentException>();
    }
    
    [TestCase(50, TestName = "{m}_OnIntegerValue")]
    [TestCase(1.5, TestName = "{m}_OnFractionalValue")]
    public void LenghtInstance_ShouldContainsPassedValue(double value)
    {
        var length = new Length(value);
        
        var lengthAsDouble = (double) length;
        
        lengthAsDouble.Should().Be(value);
    }

    [TestCase(-50, TestName = "{m}IntegerValue")]
    [TestCase(-1.5, TestName = "{m}FractionalValue")]
    public void CreateLenghtInstance_ShouldThrowException_OnNegative(double value)
    {
        var createLengthFunc = () => new Length(value);
        
        createLengthFunc.Should()
            .Throw<ArgumentException>()
            .WithMessage($"Lenght value must be greater than 0, but found {value}");
    }

    [Test]
    public void CreateLenghtInstance_ShouldThrowException_OnZero()
    {
        var createLengthFunc = () => new Length(0);
        
        createLengthFunc.Should()
            .Throw<ArgumentException>()
            .WithMessage("Lenght value must be greater than 0, but found 0");
    }
}