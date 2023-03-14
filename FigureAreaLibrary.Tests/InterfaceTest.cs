namespace FigureAreaLibrary.Tests;

public class InterfaceTest
{
    [Fact]
    public void CircleAreaTest()
    {
        IFigure figure = new Circle(2939);
        var area = figure.GetArea();
        var expeсtedArea = 27136200.837358281;
        Assert.Equal(expeсtedArea, area);
        
        figure = new Triangle(5, 13, 12);
        area = figure.GetArea();
        expeсtedArea = 30;
        Assert.Equal(expeсtedArea, area);
    }
}