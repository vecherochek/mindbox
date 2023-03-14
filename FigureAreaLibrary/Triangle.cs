namespace FigureAreaLibrary;

public class Triangle : IFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;


    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentException("Invalid side. Valid side > 0");
        }

        IsExistTriangle(a, b, c);
        _a = a;
        _b = b;
        _c = c;
    }

    public double GetArea()
    {
        var perimeter = this.GetPerimeter();
        var area = Math.Sqrt(perimeter * (perimeter - _a) * (perimeter - _b) * (perimeter - _c));
        if (double.IsPositiveInfinity(area))
            throw new OverflowException("Overflow");
        return area;
    }

    public double GetPerimeter()
    {
        var perimeter = (_a + _b + _c) / 2;
        if (double.IsPositiveInfinity(perimeter))
            throw new OverflowException("Overflow");
        return perimeter;
    }

    public bool IsRightTriangle()
    {
        if (_a > _b && _a > _c)
            return PythagoreanTheoremCheck(_a, _b, _c);
        if (_b > _a && _b > _c)
            return PythagoreanTheoremCheck(_b, _a, _c);
        return PythagoreanTheoremCheck(_c, _a, _b);
    }

    private bool PythagoreanTheoremCheck(double hypotenuse, double d, double c)
    {
        if (double.IsPositiveInfinity(hypotenuse * hypotenuse) 
            || double.IsPositiveInfinity(d * d) 
            || double.IsPositiveInfinity(c * c))
            throw new OverflowException("Overflow");
        return (hypotenuse * hypotenuse).Equals(d * d + c * c);
    }

    private void IsExistTriangle(double a, double b, double c)
    {
        if (double.IsPositiveInfinity(a + b)
            || double.IsPositiveInfinity(c + b) 
            || double.IsPositiveInfinity(a + c))
            throw new OverflowException("Overflow");
        
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("There is no such triangle");
        }
    }
}