public class Square : Shape
{
    private double _side;

    public Square(string _color, double _side) : base(_color)
    {
        this._side = _side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}