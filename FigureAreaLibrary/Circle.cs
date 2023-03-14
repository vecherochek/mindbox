namespace FigureAreaLibrary;

public class Circle: IFigure
{
    private readonly double _radius;
    
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Invalid radius. Valid radius > 0");
        _radius = radius;
    }
    public double GetArea()
    {
        var area = _radius * _radius * Math.PI;
        if (double.IsPositiveInfinity(area))
            throw new OverflowException("Overflow");
        return area;
    }
}