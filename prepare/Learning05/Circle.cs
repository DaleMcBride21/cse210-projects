public class Circle : Shape 
{
    public double _radius;
    public double _pi = Math.PI;

    public Circle(string _color, double _radius) : base(_color)
    {
        this._radius = _radius;
    }

    public override double GetArea()
    {
        return _pi * Math.Pow(_radius, 2);
    }
}