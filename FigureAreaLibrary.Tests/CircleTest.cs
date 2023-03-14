namespace FigureAreaLibrary.Tests;

public class CircleTest
{
    [Fact]
    public void CircleAreaTest()
    {
        var circle = new Circle(2939);
        var area = circle.GetArea();
        var expeсtedArea = 27136200.837358281;
        Assert.Equal(expeсtedArea, area);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-35345)]
    [InlineData(double.MinValue)]
    public void CircleAreaInvalidRadius(double r)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Circle(r));
        Assert.Equal("Invalid radius. Valid radius > 0", ex.Message);
    }
    
    [Fact]
    public void CircleAreaOverflow()
    {
        var circle = new Circle(double.MaxValue);
        var ex = Assert.Throws<OverflowException>(() => circle.GetArea());
        Assert.Equal("Overflow", ex.Message);
    }
}