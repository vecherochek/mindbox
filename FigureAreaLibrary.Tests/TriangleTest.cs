namespace FigureAreaLibrary.Tests;

public class TriangleTest
{
    [Fact]
    public void TriangleAreaTest()
    {
        var triangle = new Triangle(5, 13, 12);
        var area = triangle.GetArea();
        var expeсtedArea = 30;
        Assert.Equal(expeсtedArea, area);
    }
    
    [Fact]
    public void Overflow()
    {
        var ex = Assert.Throws<OverflowException>(() => new Triangle(double.MaxValue, double.MaxValue, double.MaxValue));
        Assert.Equal("Overflow", ex.Message);
    }
    
    [Theory]
    [InlineData(0, 10, 100)]
    [InlineData(-9, -10, 5)]
    [InlineData(double.MinValue, 11, 10)]
    public void InvalidSide(double a, double b, double c)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        Assert.Equal("Invalid side. Valid side > 0", ex.Message);
    }
    
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(25, 7, 24)]
    public void RightAngledTriangle(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        var expected = true;
        var actual = triangle.IsRightTriangle();
        Assert.Equal(expected, actual);
    }
        
    [Theory]
    [InlineData(8, 10, 4)]
    [InlineData(51.453243424, 35.123434, 30.0005)]
    public void NotRightAngledTriangle(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        var expected = false;
        var actual = triangle.IsRightTriangle();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1000, 10, 100)]
    [InlineData(12.6, 3.4534545, 140)]
    public void NotExistsTriangle(double a, double b, double c)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
            
        Assert.Equal("There is no such triangle", ex.Message);
    }
}